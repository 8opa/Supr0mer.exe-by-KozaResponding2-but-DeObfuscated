using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Supr0mer
{
	// Token: 0x02000006 RID: 6
	internal class GDISJA
	{
		// Token: 0x02000015 RID: 21
		public struct BITMAPINFOHEADER
		{
			// Token: 0x0400006E RID: 110
			public uint biSize;

			// Token: 0x0400006F RID: 111
			public int biWidth;

			// Token: 0x04000070 RID: 112
			public int biHeight;

			// Token: 0x04000071 RID: 113
			public ushort biPlanes;

			// Token: 0x04000072 RID: 114
			public ushort biBitCount;

			// Token: 0x04000073 RID: 115
			public uint biCompression;

			// Token: 0x04000074 RID: 116
			public uint biSizeImage;

			// Token: 0x04000075 RID: 117
			public int biXPelsPerMeter;

			// Token: 0x04000076 RID: 118
			public int biYPelsPerMeter;

			// Token: 0x04000077 RID: 119
			public uint biClrUsed;

			// Token: 0x04000078 RID: 120
			public uint biClrImportant;
		}

		// Token: 0x02000016 RID: 22
		public struct BITMAPINFO
		{
			// Token: 0x04000079 RID: 121
			public GDISJA.BITMAPINFOHEADER bmiHeader;

			// Token: 0x0400007A RID: 122
			public uint bmiColors;
		}

		// Token: 0x02000017 RID: 23
		public struct HSL
		{
			// Token: 0x0400007B RID: 123
			public float h;

			// Token: 0x0400007C RID: 124
			public float s;

			// Token: 0x0400007D RID: 125
			public float l;
		}

		// Token: 0x02000018 RID: 24
		internal class GDI
		{
			// Token: 0x06000071 RID: 113
			[DllImport("gdi32.dll")]
			private static extern IntPtr CreateDIBSection(IntPtr hdc, ref GDISJA.BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

			// Token: 0x06000072 RID: 114
			[DllImport("gdi32.dll")]
			private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

			// Token: 0x06000073 RID: 115
			[DllImport("gdi32.dll")]
			private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

			// Token: 0x06000074 RID: 116
			[DllImport("gdi32.dll")]
			private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, uint rop);

			// Token: 0x06000075 RID: 117
			[DllImport("user32.dll")]
			private static extern IntPtr GetDC(IntPtr hwnd);

			// Token: 0x06000076 RID: 118 RVA: 0x00002964 File Offset: 0x00000B64
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

			// Token: 0x06000077 RID: 119 RVA: 0x000045EC File Offset: 0x000027EC
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
					num2 = GDISJA.GDI.HueToRGB(num5, num4, h + 0.33333334f);
					num = GDISJA.GDI.HueToRGB(num5, num4, h);
					num3 = GDISJA.GDI.HueToRGB(num5, num4, h - 0.33333334f);
				}
				r = (byte)(num2 * 255f);
				g = (byte)(num * 255f);
				b = (byte)(num3 * 255f);
			}

			// Token: 0x06000078 RID: 120 RVA: 0x00002B1C File Offset: 0x00000D1C
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

			// Token: 0x06000079 RID: 121 RVA: 0x0000469C File Offset: 0x0000289C
			public static void clor()
			{
				DateTime now = DateTime.Now;
				TimeSpan timeSpan = TimeSpan.FromSeconds(30.0);
				while (DateTime.Now - now < timeSpan)
				{
					IntPtr dc = GDISJA.GDI.GetDC(IntPtr.Zero);
					GDISJA.BITMAPINFO bitmapinfo = default(GDISJA.BITMAPINFO);
					bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(GDISJA.BITMAPINFOHEADER));
					bitmapinfo.bmiHeader.biWidth = GDISJA.GDI.w;
					bitmapinfo.bmiHeader.biHeight = -GDISJA.GDI.hgt;
					bitmapinfo.bmiHeader.biPlanes = 1;
					bitmapinfo.bmiHeader.biBitCount = 32;
					bitmapinfo.bmiHeader.biCompression = 0U;
					IntPtr intPtr2;
					IntPtr intPtr = GDISJA.GDI.CreateDIBSection(dc, ref bitmapinfo, 0U, out intPtr2, IntPtr.Zero, 0U);
					IntPtr intPtr3 = GDISJA.GDI.CreateCompatibleDC(dc);
					GDISJA.GDI.SelectObject(intPtr3, intPtr);
					GDISJA.GDI.BitBlt(intPtr3, 0, 0, GDISJA.GDI.w, GDISJA.GDI.hgt, dc, 0, 0, 13369376U);
					int num = GDISJA.GDI.w * GDISJA.GDI.hgt;
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
							GDISJA.HSL hsl = GDISJA.GDI.RGBtoHSL(b3, b2, b);
							hsl.h += num2;
							if (hsl.h > 1f)
							{
								hsl.h -= 1f;
							}
							GDISJA.GDI.HSLtoRGB(hsl, out b3, out b2, out b);
							array[i] = (int)b | ((int)b2 << 8) | ((int)b3 << 16);
						}
						Marshal.Copy(array, 0, intPtr2, num);
						GDISJA.GDI.BitBlt(dc, 0, 0, GDISJA.GDI.w, GDISJA.GDI.hgt, intPtr3, 0, 0, 13369376U);
						Thread.Sleep(1);
					}
				}
			}

			// Token: 0x0400007E RID: 126
			private const int BI_RGB = 0;

			// Token: 0x0400007F RID: 127
			private const uint SRCCOPY = 13369376U;

			// Token: 0x04000080 RID: 128
			private static int w = 1920;

			// Token: 0x04000081 RID: 129
			private static int hgt = 1080;

			// Token: 0x04000082 RID: 130
			private static IntPtr g_hdcScreen;

			// Token: 0x04000083 RID: 131
			private static IntPtr g_hdcMem;

			// Token: 0x04000084 RID: 132
			private static IntPtr g_hbmTemp;

			// Token: 0x04000085 RID: 133
			private static int g_w;

			// Token: 0x04000086 RID: 134
			private static int g_h;
		}
	}
}
