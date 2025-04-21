// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MemoryTracker.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using System;
using System.Diagnostics;
using System.Threading;

namespace Mac_EFI_Toolkit.Common
{
    internal class MemoryTracker
    {
        #region Private Members
        private static readonly Lazy<MemoryTracker> _instance = new Lazy<MemoryTracker>(() => new MemoryTracker());
        private readonly Timer _usageTimer;
        private readonly bool _isWine;
        #endregion

        #region Internal Members
        // Event to notify UI updates on memory usage change
        internal event EventHandler<ulong> OnMemoryUsageUpdated;
        internal static MemoryTracker Instance => _instance.Value;
        #endregion

        #region Constructor
        private MemoryTracker()
        {
            _isWine = SystemTools.IsRunningUnderWine();

            if (!_isWine)
            {
                _usageTimer = new Timer(UpdateMemoryUsage, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            }
        }

        private void UpdateMemoryUsage(object state)
        {
            if (_isWine)
            {
                return;
            }

            try
            {
                string categoryName = "Process";
                PerformanceCounterCategory category = new PerformanceCounterCategory(categoryName);
                string processName = Process.GetCurrentProcess().ProcessName;
                int processId = Process.GetCurrentProcess().Id;
                string instanceName = null;

                foreach (string name in category.GetInstanceNames())
                {
                    if (name.StartsWith(processName, StringComparison.OrdinalIgnoreCase))
                    {
                        PerformanceCounter counter = new PerformanceCounter(categoryName, "ID Process", name, true);

                        if ((int)counter.RawValue == processId)
                        {
                            instanceName = name;
                            break;
                        }
                    }
                }

                if (instanceName == null)
                {
                    return;
                }

                PerformanceCounter workingSetCounter = new PerformanceCounter(categoryName, "Working Set - Private", instanceName, true);

                float bytes = workingSetCounter.NextValue();
                ulong memoryUsage = (ulong)bytes;

                OnMemoryUsageUpdated?.Invoke(this, memoryUsage);
            }
            catch { }
        }
        #endregion
    }
}