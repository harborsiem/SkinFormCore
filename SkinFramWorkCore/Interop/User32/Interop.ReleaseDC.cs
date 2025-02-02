﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System;
internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, Gdi32.HDC hDC);

        public static int ReleaseDC(HandleRef hWnd, Gdi32.HDC hDC)
        {
            int result = ReleaseDC(hWnd.Handle, hDC);
            GC.KeepAlive(hWnd.Wrapper);
            return result;
        }
    }
}
