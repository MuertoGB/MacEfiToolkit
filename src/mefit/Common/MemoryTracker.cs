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
        private string _instanceName;
        private PerformanceCounter _workingSetCounter;
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

        private void InitializeCounters()
        {
            if (_isWine || _instanceName != null)
                return;

            var category = new PerformanceCounterCategory("Process");
            var processName = Process.GetCurrentProcess().ProcessName;
            var processId = Process.GetCurrentProcess().Id;

            foreach (string name in category.GetInstanceNames())
            {
                if (name.StartsWith(processName, StringComparison.OrdinalIgnoreCase))
                {
                    var idCounter = new PerformanceCounter("Process", "ID Process", name, true);
                    if ((int)idCounter.RawValue == processId)
                    {
                        _instanceName = name;
                        _workingSetCounter = new PerformanceCounter("Process", "Working Set - Private", _instanceName, true);
                        break;
                    }
                }
            }
        }

        private void UpdateMemoryUsage(object state)
        {
            if (_isWine)
                return;

            try
            {
                InitializeCounters();

                if (_workingSetCounter == null)
                    return;

                float bytes = _workingSetCounter.NextValue();
                ulong memoryUsage = (ulong)bytes;

                OnMemoryUsageUpdated?.Invoke(this, memoryUsage);
            }
            catch { }
        }
        #endregion
    }
}