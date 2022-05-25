
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace TLSP.Common.Utilities
{
    public static class EnvironmentHelper
    {
        public static OSPlatform Platform { get; }
        public static string UserProfile { get; }
        public static string DataBase { get; }
        public static string JavaMCBase { get ; }
        public static string CacheBase { get; }
        public static string GameBase { get; }




        //public static string ComponentCacheBase { get => CacheBase + @"component\"; }
        //public static string TempCacheBase { get => CacheBase + @"temp\"; }
        //public static string SkinCacheBase { get => CacheBase + @"skin\"; }

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
                DataBase = Path.Combine(UserProfile, "AppData", "Roaming");
                JavaMCBase = Path.Combine(DataBase,".minecraft");
                
            }
            else if (Platform == OSPlatform.OSX)
            {
                DataBase = Path.Combine(UserProfile, "Library", "Application Support");
                JavaMCBase = Path.Combine(DataBase, "minecraft");
                CacheBase = Path.Combine(UserProfile, "Library", "Caches", "TLSP");
            }
            else
            {
                DataBase = UserProfile;
                JavaMCBase = Path.Combine(DataBase, ".minecraft");
            }
                

            DataBase = Path.Combine(DataBase, "TLSP");

            if (CacheBase == null)
                CacheBase = Path.Combine(DataBase,"Caches");

            GameBase = Path.Combine(DataBase, "Games");

            FileHelper.SafeCreateDir(DataBase);
            FileHelper.SafeDelete(CacheBase);
            FileHelper.SafeCreateDir(CacheBase);
            FileHelper.SafeCreateDir(GameBase);

        }
    }
}
