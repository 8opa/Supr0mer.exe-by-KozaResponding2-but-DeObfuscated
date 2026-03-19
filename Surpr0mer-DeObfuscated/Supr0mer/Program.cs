using System;
using System.Windows.Forms;

namespace Supr0mer
{
	// Token: 0x02000008 RID: 8
	internal static class Program
	{
		// Token: 0x06000060 RID: 96 RVA: 0x000020FF File Offset: 0x000002FF
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
