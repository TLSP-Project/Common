using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TLSP.Common.Extensions
{
    public static class HashExtensions
    {
        /// <summary>
        /// MD5的扩展方法，计算文件的MD5
        /// </summary>
        /// <param name="md5"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] CompleteMD5FromFile(this MD5 md5, string filePath)
        {
            using (FileStream fileSteam = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return md5.ComputeHash(fileSteam);
            }

        }
    }
}
