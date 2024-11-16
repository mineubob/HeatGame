﻿using System.Runtime.InteropServices;

static class WindowsUtils
{
    public static string? ShowOpenFileDialog(string filter)
    {
        var ofn = new WindowsNative.OPENFILENAMEA
        {
            lStructSize = (uint)Marshal.SizeOf<WindowsNative.OPENFILENAMEA>(),
            lpstrFilter = filter,
            nMaxFile = 260,
            lpstrFile = new string('\0', 260),
            lpstrFileTitle = new string('\0', 260),
            Flags = 0x00000008 | 0x00080000 | 0x00001000
        };

        if (WindowsNative.GetOpenFileNameA(ref ofn))
        {
            return ofn.lpstrFile;
        }

        return null;
    }

    public static string? ShowOpenFileDialog()
    {
        return ShowOpenFileDialog("All Files\0*.*\0");
    }

    public static bool ShowOkCancelMessageBox(string message, string caption)
    {
        return WindowsNative.MessageBoxA(IntPtr.Zero, message, caption, 0x00000001 | 0x00000020) == 1;
    }
}
