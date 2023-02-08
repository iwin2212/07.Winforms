using System.Reflection;

namespace PasApp.Utils
{
	public class Logger
	{
		public static void Log(string message)
		{
			var FolderPath = GetFolderPath();
			try
			{
				if (!Directory.Exists(FolderPath))
					Directory.CreateDirectory(FolderPath);

				SaveMessage(message);
			}
			catch (Exception e)
			{
				SaveMessage(e.Message);
				return;
			}
		}
		public static void Error(string message)
		{
			var FolderPath = GetFolderPath();
			var nameFunc = MethodBase.GetCurrentMethod().Name;
			try
			{
				if (!Directory.Exists(FolderPath))
					Directory.CreateDirectory(FolderPath);

				SaveMessage($"{nameFunc}: {message}");
			}
			catch (Exception e)
			{
				SaveMessage($"{nameFunc}: {e.Message}");
				return;
			}
		}
		public static void Info(string message)
		{
			var FolderPath = GetFolderPath();
			var nameFunc = MethodBase.GetCurrentMethod().Name;
			try
			{
				if (!Directory.Exists(FolderPath))
					Directory.CreateDirectory(FolderPath);

				SaveMessage($"{nameFunc}: {message}");
			}
			catch (Exception e)
			{
				SaveMessage($"{nameFunc}: {e.Message}");
				return;
			}
		}
		public static void Warning(string message)
		{
			var FolderPath = GetFolderPath();
			var nameFunc = MethodBase.GetCurrentMethod().Name;
			try
			{
				if (!Directory.Exists(FolderPath))
					Directory.CreateDirectory(FolderPath);

				SaveMessage($"{nameFunc}: {message}");
			}
			catch (Exception e)
			{
				SaveMessage($"{nameFunc}: {e.Message}");
				return;
			}
		}

		public static void SaveMessage(string mes)
		{
			var path = GetFilePath();
			try
			{
				if (!File.Exists(path))
				{
					using (var sw = new StreamWriter(path, true))
					{
						sw.WriteLine($"Create file {DateTime.Now:dd_MM_yyyy}.txt");
					}
				}
				File.AppendAllText(path, $"\n{DateTime.Now} - {mes}");
			}
			catch (Exception e)
			{
				File.AppendAllText(path, e.Message);
				return;
			}
		}

		public static string GetFilePath()
		{
			try
			{
				var folderPath = GetFolderPath();
				//var exe = Assembly.GetExecutingAssembly().GetName().Name + ".txt";
				var exe = $"log_{DateTime.Now:dd_MM_yyyy}.txt";
				var path = Path.Combine(folderPath, exe);
				return path;
			}
			catch
			{
				return string.Empty;
			}
		}
		public static string GetFolderPath(string subFolder = "Log")
		{
			try
			{
				var a = Assembly.GetEntryAssembly().Location;
				var folder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
				return Path.Combine(folder, subFolder);
			}
			catch
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subFolder);
			}
		}
	}
}
