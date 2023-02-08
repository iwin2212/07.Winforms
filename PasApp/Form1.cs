using System.Diagnostics;
using PasApp.Utils;

namespace PasApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			ShowWebview();
		}

		public void ShowWebview()
		{
			var filename = Path.Combine(Path.GetTempPath(), "Pas.tmp");

			if (!HasInstance(filename))
			{
				var pid = GetPid();
				CreateTmpFile(filename);
				while (true)
				{
					Logger.Info($"running with {pid}");
					if (!ProcessExists(pid))
					{
						Logger.Info($"Stop!!!");
						break;
					}
				}
			}
			else
			{
				Application.Exit();
				Environment.Exit(0);
			}
		}

		public bool HasInstance(string tmpFile)
		{
			return File.Exists(tmpFile);
		}

		public int GetPid()
		{
			System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
			return p.Id;
		}

		public bool ProcessExists(int id)
		{
			return Process.GetProcesses().Any(x => x.Id == id);
		}

		public static void CreateTmpFile(string fileName)
		{
			try
			{
				FileInfo fi = new FileInfo(fileName);
				if (File.Exists(fileName))
				{
					File.Delete(fileName);
				}
				// Create a new file     
				using (StreamWriter sw = fi.CreateText())
				{
					sw.WriteLine("Author: Nguyen Bach Thang");
				}
			}
			catch (Exception ex)
			{
				Logger.Info("Unable to create TEMP file or set its attributes: " + ex.Message);
			}
		}

		private static void DeleteTmpFile(string tmpFile)
		{
			try
			{
				if (File.Exists(tmpFile))
				{
					File.Delete(tmpFile);
					Logger.Info("TEMP file deleted.");
				}
			}
			catch (Exception ex)
			{
				Logger.Info("Error deleteing TEMP file: " + ex.Message);
			}
		}

		private void webView21_Click(object sender, EventArgs e)
		{

		}
	}
}