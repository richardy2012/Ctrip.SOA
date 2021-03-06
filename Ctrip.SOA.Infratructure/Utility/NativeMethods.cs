﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ctrip.SOA.Infratructure.Utility
{
    /// <summary>
    /// Platform Invocation methods used to support Tracer.
    /// </summary>
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetCurrentProcess();

        /// <summary>
        /// Made public for testing purposes.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentProcessId();

        /// <summary>
        /// Made public for testing purposes.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        /// <summary>
        /// Made public for testing purposes.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [PreserveSig]
        public static extern int GetModuleFileName([In] IntPtr hModule, [Out] StringBuilder lpFilename, [In][MarshalAs(UnmanagedType.U4)] int nSize);

        /// <summary>
        /// Made public for testing purposes.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetModuleHandle(string moduleName);
    }
}