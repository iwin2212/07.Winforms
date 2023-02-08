using System.Security.AccessControl;
using System.Security.Principal;

namespace PasApp.Utils
{
	public static class DirPermission
	{
		static string _lastError = "";

		/// <summary>
		/// Set Everyone Full Control permissions for selected directory
		/// </summary>
		/// <param name="dirName"></param>
		/// <returns></returns>
		public static bool SetEveryoneAccess(string dirName)
		{
			try
			{
				// Make sure directory exists
				if (Directory.Exists(dirName) == false)
					throw new Exception(string.Format("Thư mục {0} không tồn tại, không thể cấp quyền.", dirName));

				// Get directory access info
				DirectoryInfo dinfo = new DirectoryInfo(dirName);
				DirectorySecurity dSecurity = dinfo.GetAccessControl();

				// Add the FileSystemAccessRule to the security settings. 
				dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));

				// Set the access control
				dinfo.SetAccessControl(dSecurity);

				_lastError = String.Format("Đã cấp quyền FullControl truy cập thu mục {0}", dirName);

				return true;
			}
			catch (Exception ex)
			{
				_lastError = ex.Message;
				return false;
			}
		}
	}
}
