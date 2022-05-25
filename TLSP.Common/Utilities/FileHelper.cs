
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TLSP.Common.Utilities
{
    public static class FileHelper
    {
        private static readonly IInternalLogger logger = InternalLoggerFactory.GetInstance(typeof(FileHelper));


        /// <summary>
        /// 复制文件，默认覆盖
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        /// <returns>是否成功</returns>
        public static bool SafeCopyFile(string sourceFile, string destFile)
        {
            try
            {
                if (!File.Exists(sourceFile))
                    return false;
                if (!SafeCreateDirForFile(destFile))
                    return false;
                if (File.Exists(destFile))
                    File.Delete(destFile);
                File.Copy(sourceFile, destFile);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"SafeCopyFileErr sourceFile:{sourceFile} destFile{destFile}",ex);
                return false;
            }
        }

        /// <summary>
        /// 复制文件夹，默认覆盖
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destinationDir"></param>
        /// <param name="recursive">是否遍历子文件夹</param>
        /// <returns>是否成功</returns>
        public static bool SafeCopyDir(string sourceDir, string destinationDir, bool recursive = true)
        {
            try
            {
                copy(sourceDir, destinationDir, recursive);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error( $"SafeGetCreateTimeErr sourceDir:{@sourceDir} destinationDir:{destinationDir} recursive:{destinationDir}",ex);
                return false;
            }

            void copy(string sourceDir, string destinationDir, bool recursive)
            {
                // Get information about the source directory
                var dir = new DirectoryInfo(sourceDir);


                if (!dir.Exists)
                    throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");


                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!Directory.Exists(destinationDir))
                    Directory.CreateDirectory(destinationDir);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    if (File.Exists(targetFilePath))
                        File.Delete(targetFilePath);
                    file.CopyTo(targetFilePath);
                }

                // If recursive and copying subdirectories, recursively call this method
                if (recursive)
                {
                    foreach (DirectoryInfo subDir in dirs)
                    {
                        string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                        copy(subDir.FullName, newDestinationDir, true);
                    }
                }
            }
        }
        /// <summary>
        /// 获取文件创建时间
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DateTime? SafeGetCreateTime(string filePath)
        {
            try
            {
                return File.GetCreationTime(filePath);
            }
            catch (Exception ex)
            {
                logger.Error( $"SafeGetCreateTimeErr filePath:{filePath}", ex);
                return null;
            }

        }
        /// <summary>
        /// 获取文件或者目录大小，自动判断
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>获取失败返回default</returns>
        public static long SafeGetSize(string filePath)
        {
            try
            {
                if (Directory.Exists(filePath))
                    return SafeGetDirSize(filePath);
                else
                    return SafeGetFileSize(filePath);
            }
            catch (Exception ex)
            {
                logger.Error($"SafeGetSizeErr filePath:{filePath}", ex);
                return default;
            }

        }

        /// <summary>
        /// 获取目录大小
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns>获取失败返回default</returns>
        public static long SafeGetDirSize(string dirPath)
        {
            try
            {
                return new DirectoryInfo(dirPath).EnumerateFiles(".", SearchOption.AllDirectories).Sum(f => f.Length);
            }
            catch (Exception ex)
            {
                logger.Error( $"SafeGetDirSizeErr dirPath:{dirPath}", ex);
                return default;
            }

        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>获取失败返回default</returns>
        public static long SafeGetFileSize(string filePath)
        {
            try
            {
                return new FileInfo(filePath).Length;
            }
            catch (Exception ex)
            {
                logger.Error( $"SafeGetSizeErr filePath:{filePath}", ex);
                return default;
            }

        }


        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="targetName"></param>
        /// <param name="addExtension">是否添加原文件名的后缀名</param>
        /// <returns>是否成功</returns>
        public static bool SafeRenameFile(string filePath, string targetName, bool addExtension = true)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;
                File.Copy(filePath, Path.Combine(Path.GetDirectoryName(filePath), addExtension ? targetName + Path.GetExtension(filePath) : targetName), true);
                File.Delete(filePath);
                return true;
            }
            catch (Exception e)
            {
                logger.Error( $"SafeRenameFileErr filePath:{filePath} target:{targetName}", e);
            }
            return false;

        }


        /// <summary>
        /// 写入文本，覆盖原来的内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="contents"></param>
        /// <returns>是否成功</returns>
        public static bool SafeWriteText(string filePath, string contents)
        {
            try
            {
                if (!SafeCreateDirForFile(filePath))
                    return false;

                File.WriteAllText(filePath, contents);
                return true;
            }
            catch (Exception e)
            {
                logger.Error("SafeWriteTextErr filePath:" + filePath, e);
            }
            return false;

        }




        /// <summary>
        /// 为文件创建文件夹
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>是否成功</returns>
        public static bool SafeCreateDirForFile(string filePath)
        {
            try
            {
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return true;
            }
            catch (Exception e)
            {
                logger.Error("SafeCreateDirErr filePath:" + filePath, e);
            }
            return false;

        }



        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns>是否成功</returns>
        public static bool SafeCreateDir(string dirPath)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                return true;
            }
            catch (Exception e)
            {
                logger.Error( "SafeCreateDirErr dirPath:" + dirPath, e);
            }
            return false;

        }


        /// <summary>
        /// 删除文件或者文件夹，自动判断
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>是否成功</returns>
        public static bool SafeDelete(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                if (Directory.Exists(filePath))
                    Directory.Delete(filePath, true);
                return true;
            }
            catch (Exception e)
            {
                logger.Error( "SafeDeleteErr filePath:" + filePath, e);
            }
            return false;
        }


        /// <summary>
        /// 补全文件夹分隔符后缀
        /// </summary>
        /// <param name="org"></param>
        /// <param name="splitchar">用来补全的字符</param>
        /// <returns></returns>
        public static string ComplePath(string org, string splitchar = "\\")
        {
            return org.EndsWith(splitchar) ? org : org + splitchar;
        }
    }
}
