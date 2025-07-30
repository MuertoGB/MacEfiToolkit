// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MemoryTracker.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utilities;
using System;
using System.Diagnostics;
using System.Threading;

namespace Mac_EFI_Toolkit.Common
{
    public class MemoryTracker
    {
        #region Private Members
        private readonly Timer _timer;
        private readonly bool _isWine;
        private string _instanceName;
        private PerformanceCounter _performanceCounter;
        #endregion

        #region Internal Members
        // Event to notify UI updates on memory usage change.
        public event EventHandler<ulong> OnMemoryUsageUpdated;
        #endregion

        #region Constructor
        public MemoryTracker()
        {
            _isWine = SystemUtils.IsRunningUnderWine();

            if (!_isWine)
            {
                _timer = new Timer(UpdateMemoryUsage, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            }
        }

        private void InitializeCounters()
        {
            if (_isWine || _instanceName != null)
                return;

            PerformanceCounterCategory category = new PerformanceCounterCategory("Process");
            string processName = Process.GetCurrentProcess().ProcessName;
            int processId = Process.GetCurrentProcess().Id;

            foreach (string name in category.GetInstanceNames())
            {
                if (name.StartsWith(processName, StringComparison.OrdinalIgnoreCase))
                {
                    PerformanceCounter idCounter = new PerformanceCounter("Process", "ID Process", name, true);
                    if ((int)idCounter.RawValue == processId)
                    {
                        _instanceName = name;
                        _performanceCounter = new PerformanceCounter("Process", "Working Set - Private", _instanceName, true);
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

                if (_performanceCounter == null)
                    return;

                float bytes = _performanceCounter.NextValue();
                ulong memoryUsage = (ulong)bytes;

                OnMemoryUsageUpdated?.Invoke(this, memoryUsage);
            }
            catch { }
        }
        #endregion
    }
}