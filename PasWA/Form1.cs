using System.Diagnostics;
using Utils;

namespace PasWA
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			if (!IsRunningPas())
			{
				Logger.Info("start");
				InitializeComponent();
			}
			else
			{
				Logger.Info("exit");
				Application.Exit();
				Environment.Exit(0);
			}
		}

		public bool IsRunningPas()
		{
			var p = Process.GetProcessesByName("PasWA");

			if (p.Length > 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}