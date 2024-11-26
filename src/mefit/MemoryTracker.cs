// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MemoryTracker.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Mac_EFI_Toolkit
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
            _isWine = Program.IsRunningUnderWine();

            if (!_isWine)
            {
                _usageTimer = new Timer(UpdateMemoryUsage, null, TimeSpan.Zero, TimeSpan.FromSeconds(4));
            }
        }

        private void UpdateMemoryUsage(object state)
        {
            if (_isWine) return;

            IntPtr ptrHandle = NativeMethods.GetCurrentProcess();

            NativeMethods.PROCESS_MEMORY_COUNTERS pmCounters;

            if (NativeMethods.GetProcessMemoryInfo(ptrHandle, out pmCounters, (uint)Marshal.SizeOf(typeof(NativeMethods.PROCESS_MEMORY_COUNTERS))))
            {
                OnMemoryUsageUpdated?.Invoke(this, pmCounters.PagefileUsage);
            }
        }
        #endregion
    }
}