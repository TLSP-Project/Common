
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace TLSP.Common.Utilities
{
    public static class EnvironmentHelper
    {
        public static OSPlatform Platform { get; }
        public static string UserProfile { get; }
        public static string UserDataBase { get; }
        private static string _dataBase;
        public static string DataBase { 
            get {
                if (string.IsNullOrEmpty(_dataBase))
                {
                    _dataBase = Path.Combine(UserDataBase, "TLSP");
                }
                return _dataBase;    
            } 
            set { 
                _dataBase = value;

                if (Platform == OSPlatform.OSX) {
                    CacheBase = Path.Combine(UserProfile, "Library", "Caches", "TLSP");
                }
                else
                {
                    CacheBase = Path.Combine(_dataBase, "Caches");
                }

                GameBase = Path.Combine(_dataBase, "Games");

                FileHelper.SafeCreateDir(_dataBase);
                FileHelper.SafeDelete(CacheBase);
                FileHelper.SafeCreateDir(CacheBase);
                FileHelper.SafeCreateDir(GameBase);
            }
        }
        /// <summary>
        /// .minecraft路径 用户可自定义
        /// </summary>
        public static string JavaMCBase { get; set; }
        public static string CacheBase { get; private set; }
        public static string GameBase { get; private set; }

        static EnvironmentHelper()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Platform = OSPlatform.Windows;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Platform = OSPlatform.Linux;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                Platform = OSPlatform.OSX;
            else
                throw new NotSupportedException("EnvironmentHelper Init Err Not Support Currunt OSPlatform");

            UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (Platform == OSPlatform.Windows)
            {
                UserDataBase = Path.Combine(UserProfile, "AppData", "Roaming");                
            }
            else if (Platform == OSPlatform.OSX)
            {
                UserDataBase = Path.Combine(UserProfile, "Library", "Application Support");
            }
            else
            {
                UserDataBase = UserProfile;
            }

            JavaMCBase = Path.Combine(UserDataBase, ".minecraft");
        }
    }
}
