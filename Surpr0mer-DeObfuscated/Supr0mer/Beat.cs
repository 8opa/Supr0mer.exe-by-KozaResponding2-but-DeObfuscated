using System;
using System.IO;
using System.Media;

namespace Supr0mer
{
	// Token: 0x02000002 RID: 2
	internal class Beat
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002248 File Offset: 0x00000448
		public static void player()
		{
			Func<double, double>[] array = new Func<double, double>[6];
			array[0] = (double t) => 50.0 * Math.Sin(t * t * 2.0 / (double)(((int)t >> 11) + 2) / 5.75) + 128.0;
			array[1] = (double t) => t * (double)(43 & ((int)t >> 10)) + (double)(((int)t >> 3) ^ (int)t);
			array[2] = (double t) => (double)((((int)t >> 7) | (int)t | ((int)t >> 16)) * 10 + 4 * (((int)t * (int)t >> 13) | ((int)t >> 29)));
			array[3] = (double t) => (double)((int)t & ((int)t * (((int)t >> 10) | (int)(t / 11.0))));
			array[4] = (double t) => (double)((((int)t | ((int)t >> 10)) * (int)t >> 15) | ((int)t >> 19));
			array[5] = (double t) => t * (double)(43 ^ ((int)t >> 10)) + (double)((int)t >> 3) * t;
			Func<double, double>[] array2 = array;
			int[] array3 = new int[] { 30, 30, 30, 30, 30, 30 };
			int[] array4 = new int[] { 16000, 16000, 8000, 8000, 8000, 8000 };
			for (int i = 0; i < array2.Length + 1; i++)
			{
				Func<double, double> func = array2[i];
				int num = array3[i];
				int num2 = array4[i];
				int num3 = num2 * num;
				byte[] array5 = new byte[num3];
				for (int j = 0; j < num3; j++)
				{
					array5[j] = (byte)((int)func((double)j) & 255);
				}
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						binaryWriter.Write(new byte[] { 82, 73, 70, 70 });
						binaryWriter.Write(36 + array5.Length);
						binaryWriter.Write(new byte[] { 87, 65, 86, 69 });
						binaryWriter.Write(new byte[] { 102, 109, 116, 32 });
						binaryWriter.Write(16);
						binaryWriter.Write(1);
						binaryWriter.Write(1);
						binaryWriter.Write(num2);
						binaryWriter.Write(num2 * 8 / 8);
						binaryWriter.Write(1);
						binaryWriter.Write(8);
						binaryWriter.Write(new byte[] { 100, 97, 116, 97 });
						binaryWriter.Write(array5.Length);
						binaryWriter.Write(array5);
						memoryStream.Position = 0L;
						using (SoundPlayer soundPlayer = new SoundPlayer(memoryStream))
						{
							soundPlayer.PlaySync();
						}
					}
				}
			}
		}
	}
}
