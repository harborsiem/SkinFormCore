﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System;
internal static partial class Interop
{
    internal static partial class User32
    {
        // We only ever call this on 32 bit so IntPtr is correct
        [DllImport(Libraries.User32, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr SetWindowLongW(IntPtr hWnd, GWLIndex nIndex, IntPtr dwNewLong);

        [DllImport(Libraries.User32, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr SetWindowLongPtrW(IntPtr hWnd, GWLIndex nIndex, IntPtr dwNewLong);

        public static IntPtr SetWindowLong(IntPtr hWnd,  GWLIndex nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongW(hWnd, nIndex, dwNewLong);
            }

            return SetWindowLongPtrW(hWnd, nIndex, dwNewLong);
        }

        public static IntPtr SetWindowLong(IHandle hWnd,  GWLIndex nIndex, IntPtr dwNewLong)
        {
            IntPtr result = SetWindowLong(hWnd.Handle, nIndex, dwNewLong);
            GC.KeepAlive(hWnd);
            return result;
        }

        public static IntPtr SetWindowLong(IHandle hWnd,  GWLIndex nIndex, IHandle dwNewLong)
        {
            IntPtr result = SetWindowLong(hWnd.Handle, nIndex, dwNewLong.Handle);
            GC.KeepAlive(hWnd);
            GC.KeepAlive(dwNewLong);
            return result;
        }

        public static IntPtr SetWindowLong(IHandle hWnd,  GWLIndex nIndex, HandleRef dwNewLong)
        {
            IntPtr result = SetWindowLong(hWnd.Handle, nIndex, dwNewLong.Handle);
            GC.KeepAlive(hWnd);
            GC.KeepAlive(dwNewLong.Wrapper);
            return result;
        }

       
    }
}
