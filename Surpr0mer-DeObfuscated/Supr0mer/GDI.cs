using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Supr0mer
{
	// Token: 0x02000005 RID: 5
	internal class GDI
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002830 File Offset: 0x00000A30
		private static void rot()
		{
			GDI.POINT[] array = new GDI.POINT[3];
			double num = GDI.a * 0.017453292519943;
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			int num4 = GDI.sw >> 1;
			int num5 = GDI.sh >> 1;
			int num6 = -num4;
			int num7 = -num5;
			int num8 = GDI.sw - num4;
			int num9 = -num5;
			int num10 = -num4;
			int num11 = GDI.sh - num5;
			array[0].x = num4 + (int)((double)num6 * num2 - (double)num7 * num3);
			array[0].y = num5 + (int)((double)num6 * num3 + (double)num7 * num2);
			array[1].x = num4 + (int)((double)num8 * num2 - (double)num9 * num3);
			array[1].y = num5 + (int)((double)num8 * num3 + (double)num9 * num2);
			array[2].x = num4 + (int)((double)num10 * num2 - (double)num11 * num3);
			array[2].y = num5 + (int)((double)num10 * num3 + (double)num11 * num2);
			GDI.PlgBlt(GDI.rotdc, array, GDI.srcdc, 0, 0, GDI.sw, GDI.sh, IntPtr.Zero, 0, 0);
		}

		// Token: 0x0600000D RID: 13
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetDC(IntPtr intptr_0);

		// Token: 0x0600000E RID: 14
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

		// Token: 0x0600000F RID: 15
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000010 RID: 16
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000011 RID: 17
		[DllImport("gdi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool BitBlt(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, uint uint_0);

		// Token: 0x06000012 RID: 18
		[DllImport("gdi32.dll")]
		private static extern bool StretchBlt(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, int int_6, int int_7, uint uint_0);

		// Token: 0x06000013 RID: 19
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, uint uint_0);

		// Token: 0x06000014 RID: 20
		[DllImport("gdi32.dll")]
		public static extern bool GdiAlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int int_0, int int_1, int nWidthSrc, int nHeightSrc, GDI.BLENDFUNCTION blendFunction);

		// Token: 0x06000015 RID: 21
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateSolidBrush(uint uint_0);

		// Token: 0x06000016 RID: 22
		[DllImport("gdi32.dll")]
		public static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x06000017 RID: 23
		[DllImport("user32.dll")]
		private static extern IntPtr GetDesktopWindow();

		// Token: 0x06000018 RID: 24
		[DllImport("gdi32.dll")]
		private static extern bool PlgBlt(IntPtr hdc, GDI.POINT[] p, IntPtr src, int x, int y, int w, int h, IntPtr mask, int mx, int my);

		// Token: 0x06000019 RID: 25
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowDC(IntPtr intptr_0);

		// Token: 0x0600001A RID: 26
		[DllImport("user32.dll")]
		private static extern bool InvalidateRect(IntPtr intptr_0, IntPtr intptr_1, bool bool_0);

		// Token: 0x0600001B RID: 27
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

		// Token: 0x0600001C RID: 28
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_0, int int_0, int int_1);

		// Token: 0x0600001D RID: 29
		[DllImport("user32.dll")]
		private static extern bool DrawIcon(IntPtr intptr_0, int int_0, int int_1, IntPtr intptr_1);

		// Token: 0x0600001E RID: 30
		[DllImport("user32.dll")]
		private static extern IntPtr LoadCursor(IntPtr intptr_0, int int_0);

		// Token: 0x0600001F RID: 31
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000020 RID: 32
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

		// Token: 0x06000021 RID: 33
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateDIBSection(IntPtr hdc, ref GDI.BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

		// Token: 0x06000022 RID: 34
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(int vKey);

		// Token: 0x06000023 RID: 35
		[DllImport("kernel32.dll")]
		private static extern bool QueryPerformanceCounter(out GDI.LARGE_INTEGER val);

		// Token: 0x06000024 RID: 36
		[DllImport("kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(out GDI.LARGE_INTEGER val);

		// Token: 0x06000025 RID: 37 RVA: 0x000020B1 File Offset: 0x000002B1
		private static int RGBQ(int r, int g, int b)
		{
			return r | (g << 8) | (b << 16);
		}

		// Token: 0x06000026 RID: 38
		[DllImport("gdi32.dll")]
		private static extern int SetDIBitsToDevice(IntPtr hdc, int x, int y, int w, int h, int srcX, int srcY, uint start, uint lines, IntPtr bits, ref GDI.BITMAPINFO bmi, uint usage);

		// Token: 0x06000027 RID: 39
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(IntPtr hdc, int x, int y, int w, int h, int rop);

		// Token: 0x06000028 RID: 40
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateSolidBrush(int color);

		// Token: 0x06000029 RID: 41 RVA: 0x00002964 File Offset: 0x00000B64
		private static GDISJA.HSL RGBtoHSL(byte r, byte g, byte b)
		{
			float num = (float)r / 255f;
			float num2 = (float)g / 255f;
			float num3 = (float)b / 255f;
			float num4 = Math.Max(num, Math.Max(num2, num3));
			float num5 = Math.Min(num, Math.Min(num2, num3));
			float num6 = (num4 + num5) / 2f;
			float num7;
			float num8;
			if (num4 == num5)
			{
				num7 = 0f;
				num8 = 0f;
			}
			else
			{
				float num9 = num4 - num5;
				num8 = ((num6 > 0.5f) ? (num9 / (2f - num4 - num5)) : (num9 / (num4 + num5)));
				if (num4 == num)
				{
					num7 = (num2 - num3) / num9 + (float)((num2 < num3) ? 6 : 0);
				}
				else if (num4 == num2)
				{
					num7 = (num3 - num) / num9 + 2f;
				}
				else
				{
					num7 = (num - num2) / num9 + 4f;
				}
				num7 /= 6f;
			}
			return new GDISJA.HSL
			{
				h = num7,
				s = num8,
				l = num6
			};
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002A6C File Offset: 0x00000C6C
		private static void HSLtoRGB(GDISJA.HSL hsl, out byte r, out byte g, out byte b)
		{
			float h = hsl.h;
			float s = hsl.s;
			float l = hsl.l;
			float num3;
			float num2;
			float num;
			if (s == 0f)
			{
				num = (num2 = (num3 = l));
			}
			else
			{
				float num4 = ((l < 0.5f) ? (l * (1f + s)) : (l + s - l * s));
				float num5 = 2f * l - num4;
				num2 = GDI.HueToRGB(num5, num4, h + 0.33333334f);
				num = GDI.HueToRGB(num5, num4, h);
				num3 = GDI.HueToRGB(num5, num4, h - 0.33333334f);
			}
			r = (byte)(num2 * 255f);
			g = (byte)(num * 255f);
			b = (byte)(num3 * 255f);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B1C File Offset: 0x00000D1C
		private static float HueToRGB(float p, float q, float t)
		{
			if (t < 0f)
			{
				t += 1f;
			}
			if (t > 1f)
			{
				t -= 1f;
			}
			float num;
			if (t < 0.16666667f)
			{
				num = p + (q - p) * 6f * t;
			}
			else if (t < 0.5f)
			{
				num = q;
			}
			else if (t < 0.6666667f)
			{
				num = p + (q - p) * (0.6666667f - t) * 6f;
			}
			else
			{
				num = p;
			}
			return num;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002B9C File Offset: 0x00000D9C
		public static void Sine()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				IntPtr intPtr = GDI.CreateCompatibleDC(dc);
				IntPtr intPtr2 = GDI.CreateCompatibleBitmap(dc, systemMetrics, systemMetrics2);
				IntPtr intPtr3 = GDI.SelectObject(intPtr, intPtr2);
				double num = 0.0;
				try
				{
					while (DateTime.Now - now < timeSpan)
					{
						GDI.BitBlt(intPtr, 0, 0, systemMetrics, systemMetrics2, dc, 0, 0, 13369376U);
						for (int i = 0; i < systemMetrics; i++)
						{
							double num2 = Math.Sin(num + (double)i * 0.07 * (double)GDI.distortionX) * (double)GDI.distortionY;
							int num3 = (int)Math.Round(num2);
							GDI.BitBlt(dc, i, num3, 1, systemMetrics2, intPtr, i, 0, 13369376U);
						}
						num += (double)GDI.SpeedFactor;
						Thread.Sleep(1);
					}
				}
				finally
				{
					GDI.SelectObject(intPtr, intPtr3);
					GDI.DeleteObject(intPtr2);
					GDI.DeleteDC(intPtr);
					GDI.ReleaseDC(IntPtr.Zero, dc);
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public static void scroll()
		{
			int num = 1;
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int width = Screen.PrimaryScreen.Bounds.Width;
				int height = Screen.PrimaryScreen.Bounds.Height;
				new Random();
				IntPtr intPtr = GDI.CreateCompatibleDC(dc);
				IntPtr intPtr2 = GDI.CreateCompatibleBitmap(dc, width, height);
				IntPtr intPtr3 = GDI.SelectObject(intPtr, intPtr2);
				GDI.BitBlt(intPtr, 0, 0, width, height, dc, 0, 0, 13369376U);
				GDI.BitBlt(dc, num, 0, width, height, intPtr, 0, 0, 13369376U);
				GDI.BitBlt(dc, -width + num, 0, width, height, intPtr, 0, 0, 13369376U);
				num++;
				Thread.Sleep(50);
				GDI.DeleteDC(dc);
				GDI.DeleteDC(intPtr);
				GDI.DeleteObject(intPtr2);
				GDI.DeleteObject(intPtr3);
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002DFC File Offset: 0x00000FFC
		public static void DrawLOLZ()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(60.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				int num = GDI.rand.Next(0, systemMetrics - 32);
				int num2 = GDI.rand.Next(0, systemMetrics2 - 32);
				IntPtr intPtr = GDI.LoadIcon(IntPtr.Zero, new IntPtr(32513));
				GDI.DrawIcon(dc, num, num2, intPtr);
				Thread.Sleep(1);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002E9C File Offset: 0x0000109C
		public static void kid()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				double num = 0.0;
				while (DateTime.Now - now < timeSpan)
				{
					double num2 = num;
					for (int i = 0; i < systemMetrics2; i++)
					{
						int num3 = (int)(Math.Sin(num2) * 30.0);
						GDI.BitBlt(dc, 0, i, systemMetrics, 1, dc, num3, i, 13369376U);
						num2 += 0.1;
					}
					num += 0.15;
					Thread.Sleep(1);
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002F78 File Offset: 0x00001178
		public static void color()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				GDI.BITMAPINFO bitmapinfo = default(GDI.BITMAPINFO);
				bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(GDI.BITMAPINFOHEADER));
				bitmapinfo.bmiHeader.biWidth = GDI.w;
				bitmapinfo.bmiHeader.biHeight = -GDI.hgt;
				bitmapinfo.bmiHeader.biPlanes = 1;
				bitmapinfo.bmiHeader.biBitCount = 32;
				bitmapinfo.bmiHeader.biCompression = 0U;
				IntPtr intPtr2;
				IntPtr intPtr = GDI.CreateDIBSection(dc, ref bitmapinfo, 0U, out intPtr2, IntPtr.Zero, 0U);
				IntPtr intPtr3 = GDI.CreateCompatibleDC(dc);
				GDI.SelectObject(intPtr3, intPtr);
				GDI.BitBlt(intPtr3, 0, 0, GDI.w, GDI.hgt, dc, 0, 0, 13369376U);
				int num = GDI.w * GDI.hgt;
				int[] array = new int[num];
				Marshal.Copy(intPtr2, array, 0, num);
				new Random();
				float num2 = 0.1f;
				while (DateTime.Now - now < timeSpan)
				{
					for (int i = 0; i < num; i++)
					{
						int num3 = array[i];
						byte b = (byte)(num3 & 255);
						byte b2 = (byte)((num3 / 8) & 255);
						byte b3 = (byte)((num3 >> 16) & 255);
						GDISJA.HSL hsl = GDI.RGBtoHSL(b3, b2, b);
						hsl.h += num2;
						if (hsl.h > 1f)
						{
							hsl.h -= 1f;
						}
						GDI.HSLtoRGB(hsl, out b3, out b2, out b);
						array[i] = (int)b | ((int)b2 << 8) | ((int)b3 << 16);
					}
					Marshal.Copy(array, 0, intPtr2, num);
					GDI.BitBlt(dc, 0, 0, GDI.w, GDI.hgt, intPtr3, 0, 0, 13369376U);
					Thread.Sleep(1);
				}
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003188 File Offset: 0x00001388
		public static void noise()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				GDI.sdc = GDI.GetDC(IntPtr.Zero);
				GDI.sw = GDI.GetSystemMetrics(0);
				GDI.sh = GDI.GetSystemMetrics(1);
				GDI.srcdc = GDI.CreateCompatibleDC(GDI.sdc);
				GDI.rotdc = GDI.CreateCompatibleDC(GDI.sdc);
				GDI.outdc = GDI.CreateCompatibleDC(GDI.sdc);
				GDI.BITMAPINFO bitmapinfo = default(GDI.BITMAPINFO);
				bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(GDI.BITMAPINFOHEADER));
				bitmapinfo.bmiHeader.biWidth = GDI.sw;
				bitmapinfo.bmiHeader.biHeight = -GDI.sh;
				bitmapinfo.bmiHeader.biPlanes = 1;
				bitmapinfo.bmiHeader.biBitCount = 32;
				bitmapinfo.bmiHeader.biCompression = 0U;
				IntPtr intPtr = GDI.CreateDIBSection(GDI.sdc, ref bitmapinfo, 0U, out GDI.srcbits, IntPtr.Zero, 0U);
				IntPtr intPtr2 = GDI.CreateDIBSection(GDI.sdc, ref bitmapinfo, 0U, out GDI.rotbits, IntPtr.Zero, 0U);
				IntPtr intPtr3 = GDI.CreateDIBSection(GDI.sdc, ref bitmapinfo, 0U, out GDI.outbits, IntPtr.Zero, 0U);
				GDI.SelectObject(GDI.srcdc, intPtr);
				GDI.SelectObject(GDI.rotdc, intPtr2);
				GDI.SelectObject(GDI.outdc, intPtr3);
				GDI.POINT[] array = new GDI.POINT[3];
				double num = GDI.a * 0.017453292519943;
				double num2 = Math.Cos(num);
				double num3 = Math.Sin(num);
				int num4 = GDI.sw >> 1;
				int num5 = GDI.sh >> 1;
				int num6 = -num4;
				int num7 = -num5;
				int num8 = GDI.sw - num4;
				int num9 = -num5;
				int num10 = -num4;
				int num11 = GDI.sh - num5;
				array[0].x = num4 + (int)((double)num6 * num2 - (double)num7 * num3);
				array[0].y = num5 + (int)((double)num6 * num3 + (double)num7 * num2);
				array[1].x = num4 + (int)((double)num8 * num2 - (double)num9 * num3);
				array[1].y = num5 + (int)((double)num8 * num3 + (double)num9 * num2);
				array[2].x = num4 + (int)((double)num10 * num2 - (double)num11 * num3);
				array[2].y = num5 + (int)((double)num10 * num3 + (double)num11 * num2);
				GDI.BitBlt(GDI.srcdc, 0, 0, GDI.sw, GDI.sh, GDI.sdc, 0, 0, 13369376U);
				GDI.BitBlt(GDI.rotdc, 0, 0, GDI.sw, GDI.sh, GDI.srcdc, 0, 0, 13369376U);
				GDI.BitBlt(GDI.outdc, 0, 0, GDI.sw, GDI.sh, GDI.rotdc, 0, 0, 13369376U);
				while (DateTime.Now - now < timeSpan)
				{
					double num12 = (double)(GDI.rand.Next(2000) + 1) / 100.0;
					GDI.a += (double)GDI.dir * 0.1;
					if (GDI.a >= num12)
					{
						GDI.a = 0.0;
						GDI.dir = -1;
					}
					if (GDI.a <= -num12)
					{
						GDI.a = 0.0;
						GDI.dir = 1;
					}
					GDI.PlgBlt(GDI.rotdc, array, GDI.srcdc, 0, 0, GDI.sw, GDI.sh, IntPtr.Zero, 0, 0);
					GDI.BitBlt(GDI.outdc, 0, 0, GDI.sw, GDI.sh, GDI.rotdc, 0, 0, 13369376U);
					Thread.Sleep(1);
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003564 File Offset: 0x00001764
		public static void InvertColor()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				GDI.BitBlt(dc, 0, 0, systemMetrics, systemMetrics2, dc, 0, 0, 5570569U);
				Thread.Sleep(5);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000035D0 File Offset: 0x000017D0
		public static void SHAKE()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				int num = GDI.rand.Next(-10, 10);
				int num2 = GDI.rand.Next(-10, 10);
				GDI.BitBlt(dc, num, num2, systemMetrics, systemMetrics2, dc, 0, 0, 13369376U);
				Thread.Sleep(5);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003660 File Offset: 0x00001860
		public static void SRAMD()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				GDI.BitBlt(dc, 0, 0, systemMetrics, systemMetrics2, dc, 0, 0, 8913094U);
				Thread.Sleep(5);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000036CC File Offset: 0x000018CC
		public static void hi()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				IntPtr intPtr = GDI.CreateCompatibleDC(dc);
				IntPtr intPtr2 = GDI.CreateCompatibleBitmap(dc, systemMetrics, systemMetrics2);
				IntPtr intPtr3 = GDI.SelectObject(intPtr, intPtr2);
				double num = 0.0;
				int num2 = 1;
				int num3 = 7;
				int num4 = 5;
				int num5 = 6;
				double num6 = 12.0;
				double num7 = 0.01;
				double num8 = 0.5;
				int num9 = 16;
				int[] array = new int[5];
				for (int i = 0; i < num4; i++)
				{
					double num10 = ((double)i + 0.5) * (double)systemMetrics / (double)num4;
					array[i] = (int)Math.Round(num10) - num5 / 2;
					if (array[i] < 0)
					{
						array[i] = 0;
					}
					if (array[i] > systemMetrics - num5)
					{
						array[i] = systemMetrics - num5;
					}
				}
				Random random = new Random(12345);
				double[] array2 = new double[systemMetrics];
				for (int j = 0; j < systemMetrics; j++)
				{
					array2[j] = (random.NextDouble() - 0.5) * 0.8;
				}
				try
				{
					while (DateTime.Now - now < timeSpan)
					{
						GDI.BitBlt(intPtr, 0, 0, systemMetrics, systemMetrics2, dc, 0, 0, 13369376U);
						int k = 0;
						IL_02BF:
						while (k < systemMetrics)
						{
							bool flag = false;
							for (int l = 0; l < num4; l++)
							{
								int num11 = array[l];
								if (k >= num11 && k < num11 + num5)
								{
									double num12 = Math.Tan(num + (double)k * num7 + array2[k]) * num6 * 0.9;
									int num13 = (int)num12;
									if (num13 < -systemMetrics2)
									{
										num13 = -systemMetrics2;
									}
									if (num13 > systemMetrics2)
									{
										num13 = systemMetrics2;
									}
									int num14 = Math.Min(num5, systemMetrics - k);
									GDI.BitBlt(dc, k, num13, num14, systemMetrics2, intPtr, k, 0, 13369376U);
									flag = true;
									IL_01FF:
									if (!flag)
									{
										int num15 = systemMetrics2 / num3;
										for (int m = 0; m < num3; m++)
										{
											int num16 = m * num15;
											int num17 = ((m == num3 - 1) ? (systemMetrics2 - num16) : num15);
											double num18 = num + (double)k * num7 + (double)m * num8 + array2[k];
											double num19 = Math.Tan(num18) * (num6 * (1.0 + (double)m * 0.12));
											int num20 = num16 + (int)num19;
											if (num20 < -systemMetrics2)
											{
												num20 = -systemMetrics2;
											}
											if (num20 > systemMetrics2)
											{
												num20 = systemMetrics2;
											}
											GDI.BitBlt(dc, k, num20, num2, num17, intPtr, k, num16, 13369376U);
										}
									}
									k += num2;
									goto IL_02BF;
								}
							}
							goto IL_01FF;
						}
						num += (double)GDI.SpeedFactor;
						Thread.Sleep(num9);
					}
				}
				finally
				{
					GDI.SelectObject(intPtr, intPtr3);
					GDI.DeleteObject(intPtr2);
					GDI.DeleteDC(intPtr);
					GDI.ReleaseDC(IntPtr.Zero, dc);
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003A28 File Offset: 0x00001C28
		public static void circles()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
			while (DateTime.Now - now < timeSpan)
			{
				IntPtr dc = GDI.GetDC(IntPtr.Zero);
				int systemMetrics = GDI.GetSystemMetrics(0);
				int systemMetrics2 = GDI.GetSystemMetrics(1);
				double num = 0.0;
				while (DateTime.Now - now < timeSpan)
				{
					double num2 = num;
					for (int i = 0; i < systemMetrics2; i++)
					{
						int num3 = (int)(Math.Tan(num2) * 30.0);
						GDI.BitBlt(dc, 0, i, systemMetrics, 1, dc, num3, i, 13369376U);
						num2 += 0.1;
					}
					num += 0.15;
					Thread.Sleep(1);
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003B04 File Offset: 0x00001D04
		public unsafe static void LSD()
		{
			Random random = new Random();
			int systemMetrics = GDI.GetSystemMetrics(0);
			int systemMetrics2 = GDI.GetSystemMetrics(1);
			IntPtr dc = GDI.GetDC(IntPtr.Zero);
			IntPtr intPtr = GDI.CreateCompatibleDC(dc);
			GDI.BITMAPINFO bitmapinfo = default(GDI.BITMAPINFO);
			bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(GDI.BITMAPINFOHEADER));
			bitmapinfo.bmiHeader.biWidth = systemMetrics;
			bitmapinfo.bmiHeader.biHeight = -systemMetrics2;
			bitmapinfo.bmiHeader.biPlanes = 1;
			bitmapinfo.bmiHeader.biBitCount = 32;
			bitmapinfo.bmiHeader.biCompression = 0U;
			IntPtr intPtr3;
			IntPtr intPtr2 = GDI.CreateDIBSection(intPtr, ref bitmapinfo, 0U, out intPtr3, IntPtr.Zero, 0U);
			GDI.SelectObject(intPtr, intPtr2);
			uint[] array = new uint[systemMetrics * systemMetrics2];
			uint[] array2 = new uint[systemMetrics * systemMetrics2];
			GDI.LARGE_INTEGER large_INTEGER;
			GDI.QueryPerformanceFrequency(out large_INTEGER);
			GDI.LARGE_INTEGER large_INTEGER2;
			GDI.QueryPerformanceCounter(out large_INTEGER2);
			int num = 0;
			uint[] array3;
			uint* ptr;
			if ((array3 = array) != null && array3.Length != 0)
			{
				ptr = &array3[0];
			}
			else
			{
				ptr = null;
			}
			uint[] array4;
			uint* ptr2;
			if ((array4 = array2) != null && array4.Length != 0)
			{
				ptr2 = &array4[0];
			}
			else
			{
				ptr2 = null;
			}
			for (;;)
			{
				GDI.BitBlt(intPtr, 0, 0, systemMetrics, systemMetrics2, dc, 0, 0, 13369376U);
				uint* ptr3 = (uint*)(void*)intPtr3;
				GDI.LARGE_INTEGER large_INTEGER3;
				GDI.QueryPerformanceCounter(out large_INTEGER3);
				float num2 = (float)((double)(large_INTEGER3.QuadPart - large_INTEGER2.QuadPart) / (double)large_INTEGER.QuadPart);
				float num3 = (float)Math.Sin((double)num2 * 0.8 + (double)num * 0.002) * 9.99f;
				float num4 = 0.45f + 0.35f * (float)Math.Sin((double)num2 * 2.1);
				float num5 = 8f + 8f * (float)Math.Sin((double)(num2 * 9f + 0.7f * (float)num));
				float num6 = 3f + 3f * (float)Math.Sin((double)num2 * 3.3);
				float num7 = 0.85f;
				int num8 = systemMetrics / 2;
				int num9 = systemMetrics2 / 2;
				for (int i = 0; i < systemMetrics2; i++)
				{
					int num10 = i * systemMetrics;
					float num11 = (float)(i - num9) / (float)systemMetrics2;
					for (int j = 0; j < systemMetrics; j++)
					{
						float num12 = (float)(j - num8) / (float)systemMetrics;
						float num13 = (float)Math.Sqrt((double)(num12 * num12 + num11 * num11));
						float num14 = (float)Math.Atan2((double)num11, (double)num12);
						float num15 = 0.0045f * (float)Math.Sin((double)((float)(j + i) * 0.013f + num2 * 6f));
						float num16 = num14 + num3 * (1f + num4 * num13) + num15;
						float num17 = 1f / (0.4f + num13 * 0.9f);
						float num18 = (float)Math.Cos((double)num16) * num13 * num17;
						float num19 = (float)Math.Sin((double)num16) * num13 * num17;
						float num20 = (num18 + 0.5f) * (float)systemMetrics + 6f * (float)Math.Sin((double)(num2 * 12f + num13 * 40f));
						float num21 = (num19 + 0.5f) * (float)systemMetrics2 + 6f * (float)Math.Cos((double)(num2 * 10f + num13 * 30f));
						int num22 = ((int)num20 % systemMetrics + systemMetrics) % systemMetrics;
						int num23 = ((int)num21 % systemMetrics2 + systemMetrics2) % systemMetrics2;
						int num24 = (int)((double)num5 * Math.Sin((double)(num2 * 10f) + (double)j * 0.0015 + (double)i * 0.0012));
						int num25 = (num22 + num24 + systemMetrics) % systemMetrics;
						int num26 = (num22 - num24 + systemMetrics) % systemMetrics;
						uint num27 = ptr3[num23 * systemMetrics + num25];
						uint num28 = ptr3[num23 * systemMetrics + num22];
						uint num29 = ptr3[num23 * systemMetrics + num26];
						int num30 = (int)((num27 >> 16) & 255U);
						int num31 = (int)((num28 >> 8) & 255U);
						int num32 = (int)(num29 & 255U);
						int num33 = 1 + (int)((double)num6 * (0.5 + 0.5 * Math.Sin((double)(num2 * 5f) + (double)j * 0.005)));
						int num34 = num22 / num33 * num33;
						int num35 = num23 / num33 * num33;
						uint num36 = ptr3[(num35 + (num >> 1) % num33) % systemMetrics2 * systemMetrics + (num34 + (num >> 1) % num33) % systemMetrics];
						int num37 = (int)((num36 >> 16) & 255U);
						int num38 = (int)((num36 >> 8) & 255U);
						int num39 = (int)(num36 & 255U);
						int num40 = num30 * 3 + num37 >> 2;
						int num41 = num31 * 3 + num38 >> 2;
						int num42 = num32 * 3 + num39 >> 2;
						if ((i & 1) == 0)
						{
							num40 = num40 * 85 / 100;
							num41 = num41 * 85 / 100;
							num42 = num42 * 85 / 100;
						}
						float num43 = 0.5f + 0.5f * (float)Math.Sin((double)(num2 * 40f) + (double)j * 0.02 + (double)i * 0.014);
						num40 = (int)((float)num40 * (0.6f + 0.4f * num43));
						num41 = (int)((float)num41 * (0.6f + 0.4f * num43));
						num42 = (int)((float)num42 * (0.6f + 0.4f * num43));
						int num44 = num10 + j;
						uint num45 = ptr2[num44];
						int num46 = (int)((num45 >> 16) & 255U);
						int num47 = (int)((num45 >> 8) & 255U);
						int num48 = (int)(num45 & 255U);
						num40 = (int)((float)num40 * (1f - num7) + (float)num46 * num7);
						num41 = (int)((float)num41 * (1f - num7) + (float)num47 * num7);
						num42 = (int)((float)num42 * (1f - num7) + (float)num48 * num7);
						ptr[num44] = (uint)(-16777216 | (num40 << 16) | (num41 << 8) | num42);
					}
				}
				int num49 = (int)(4.0 * Math.Sin((double)(num2 * 20f)) + (double)(random.Next(7) - 3));
				int num50 = (int)(4.0 * Math.Cos((double)(num2 * 18f)) + (double)(random.Next(7) - 3));
				GDI.BitBlt(dc, num49, num50, systemMetrics, systemMetrics2, dc, 0, 0, 6684742U);
				uint[] array5;
				uint* ptr4;
				if ((array5 = array) != null && array5.Length != 0)
				{
					ptr4 = &array5[0];
				}
				else
				{
					ptr4 = null;
				}
				GDI.SetDIBitsToDevice(dc, 0, 0, systemMetrics, systemMetrics2, 0, 0, 0U, (uint)systemMetrics2, (IntPtr)((void*)ptr4), ref bitmapinfo, 0U);
				array5 = null;
				int num51 = 3 + random.Next(3);
				for (int k = 0; k < num51; k++)
				{
					int num52 = (int)(128.0 + 127.0 * Math.Sin((double)(num2 * (float)(7 + k) + (float)k)));
					int num53 = (int)(128.0 + 127.0 * Math.Sin((double)num2 * (8.3 + (double)k * 0.6) + (double)k * 1.3));
					int num54 = (int)(128.0 + 127.0 * Math.Sin((double)num2 * (9.1 + (double)k * 0.9) + (double)k * 2.1));
					IntPtr intPtr4 = GDI.CreateSolidBrush(GDI.RGBQ(num52, num53, num54));
					IntPtr intPtr5 = GDI.SelectObject(dc, intPtr4);
					GDI.PatBlt(dc, 0, 0, systemMetrics, systemMetrics2, 5898313);
					GDI.SelectObject(dc, intPtr5);
					GDI.DeleteObject(intPtr4);
				}
				for (int l = 0; l < 3; l++)
				{
					int num55 = random.Next(9) - 4;
					int num56 = random.Next(9) - 4;
					int num57 = (((l & 1) == 1) ? 15597702 : 8913094);
					GDI.BitBlt(dc, num55, num56, systemMetrics, systemMetrics2, dc, 0, 0, (uint)num57);
				}
				if ((num & 7) == 0)
				{
					GDI.PatBlt(dc, 0, 0, systemMetrics, systemMetrics2, 5898313);
				}
				Array.Copy(array, array2, array.Length);
				num++;
			}
		}

		// Token: 0x04000002 RID: 2
		private static IntPtr sdc;

		// Token: 0x04000003 RID: 3
		private static IntPtr srcdc;

		// Token: 0x04000004 RID: 4
		private static IntPtr rotdc;

		// Token: 0x04000005 RID: 5
		private static IntPtr outdc;

		// Token: 0x04000006 RID: 6
		private static IntPtr srcbits;

		// Token: 0x04000007 RID: 7
		private static IntPtr rotbits;

		// Token: 0x04000008 RID: 8
		private static IntPtr outbits;

		// Token: 0x04000009 RID: 9
		private static int sw;

		// Token: 0x0400000A RID: 10
		private static int sh;

		// Token: 0x0400000B RID: 11
		private static double a = 0.0;

		// Token: 0x0400000C RID: 12
		private static int dir = 1;

		// Token: 0x0400000D RID: 13
		private const int BI_RGB = 0;

		// Token: 0x0400000E RID: 14
		private static int w = 1920;

		// Token: 0x0400000F RID: 15
		private static int hgt = 1080;

		// Token: 0x04000010 RID: 16
		private const uint SRCERASE = 4457256U;

		// Token: 0x04000011 RID: 17
		public const uint DSTINVERT = 5570569U;

		// Token: 0x04000012 RID: 18
		public const uint SRCAND = 8913094U;

		// Token: 0x04000013 RID: 19
		private const uint DIB_RGB_COLORS = 0U;

		// Token: 0x04000014 RID: 20
		private static GDI.RGB[] g_rgbScreen;

		// Token: 0x04000015 RID: 21
		private const int SRCINVERT = 6684742;

		// Token: 0x04000016 RID: 22
		private const int SRCPAINT = 15597702;

		// Token: 0x04000017 RID: 23
		private const int PATINVERT = 5898313;

		// Token: 0x04000018 RID: 24
		private const int BLACKNESS = 66;

		// Token: 0x04000019 RID: 25
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400001A RID: 26
		private const int SM_CYSCREEN = 1;

		// Token: 0x0400001B RID: 27
		private static IntPtr g_hdcScreen;

		// Token: 0x0400001C RID: 28
		private static IntPtr g_hdcMem;

		// Token: 0x0400001D RID: 29
		private static IntPtr g_hbmTemp;

		// Token: 0x0400001E RID: 30
		private static int g_w;

		// Token: 0x0400001F RID: 31
		private static int g_h;

		// Token: 0x04000020 RID: 32
		private const int SRCCOPY = 13369376;

		// Token: 0x04000021 RID: 33
		public static float SpeedFactor = 0.15f;

		// Token: 0x04000022 RID: 34
		public static int distortionX = 1;

		// Token: 0x04000023 RID: 35
		public static int distortionY = 5;

		// Token: 0x04000024 RID: 36
		public static Random rand = new Random();

		// Token: 0x0200000D RID: 13
		private struct BITMAPINFOHEADER
		{
			// Token: 0x0400004E RID: 78
			public uint biSize;

			// Token: 0x0400004F RID: 79
			public int biWidth;

			// Token: 0x04000050 RID: 80
			public int biHeight;

			// Token: 0x04000051 RID: 81
			public ushort biPlanes;

			// Token: 0x04000052 RID: 82
			public ushort biBitCount;

			// Token: 0x04000053 RID: 83
			public uint biCompression;

			// Token: 0x04000054 RID: 84
			public uint biSizeImage;

			// Token: 0x04000055 RID: 85
			public int biXPelsPerMeter;

			// Token: 0x04000056 RID: 86
			public int biYPelsPerMeter;

			// Token: 0x04000057 RID: 87
			public uint biClrUsed;

			// Token: 0x04000058 RID: 88
			public uint biClrImportant;
		}

		// Token: 0x0200000E RID: 14
		public struct BLENDFUNCTION
		{
			// Token: 0x06000070 RID: 112 RVA: 0x00002204 File Offset: 0x00000404
			public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
			{
				this.BlendOp = op;
				this.BlendFlags = flags;
				this.SourceConstantAlpha = alpha;
				this.AlphaFormat = format;
			}

			// Token: 0x04000059 RID: 89
			private byte BlendOp;

			// Token: 0x0400005A RID: 90
			private byte BlendFlags;

			// Token: 0x0400005B RID: 91
			private byte SourceConstantAlpha;

			// Token: 0x0400005C RID: 92
			private byte AlphaFormat;

			// Token: 0x02000020 RID: 32
			private struct BITMAPINFO
			{
				// Token: 0x0400008E RID: 142
				public GDI.BITMAPINFOHEADER bmiHeader;

				// Token: 0x0400008F RID: 143
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
				public uint[] bmiColors;
			}
		}

		// Token: 0x0200000F RID: 15
		private struct BITMAPINFO
		{
			// Token: 0x0400005D RID: 93
			public GDI.BITMAPINFOHEADER bmiHeader;

			// Token: 0x0400005E RID: 94
			public uint bmiColors;
		}

		// Token: 0x02000010 RID: 16
		private struct LARGE_INTEGER
		{
			// Token: 0x0400005F RID: 95
			public long QuadPart;
		}

		// Token: 0x02000011 RID: 17
		public struct RGB
		{
			// Token: 0x04000060 RID: 96
			public byte b;

			// Token: 0x04000061 RID: 97
			public byte g;

			// Token: 0x04000062 RID: 98
			public byte r;

			// Token: 0x04000063 RID: 99
			public byte a;
		}

		// Token: 0x02000012 RID: 18
		public struct RGBQUAD
		{
			// Token: 0x04000064 RID: 100
			public byte B;

			// Token: 0x04000065 RID: 101
			public byte G;

			// Token: 0x04000066 RID: 102
			public byte R;

			// Token: 0x04000067 RID: 103
			public byte A;
		}

		// Token: 0x02000013 RID: 19
		private struct POINT
		{
			// Token: 0x04000068 RID: 104
			public int x;

			// Token: 0x04000069 RID: 105
			public int y;

			// Token: 0x0400006A RID: 106
			internal int Y;

			// Token: 0x0400006B RID: 107
			internal int X;
		}

		// Token: 0x02000014 RID: 20
		private struct BITMAPPROBLEM
		{
			// Token: 0x0400006C RID: 108
			public GDI.BITMAPINFOHEADER bmiHeader;

			// Token: 0x0400006D RID: 109
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
			public uint[] bmiColors;
		}
	}
}
