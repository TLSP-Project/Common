using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using TLSP.Common.Extensions;

namespace TLSP.Common.Utilities
{
    public static class HashHelper
    {
        private static readonly IInternalLogger logger = InternalLoggerFactory.GetInstance(typeof(HashHelper));   

        private static readonly ThreadLocal<MD5>  md5 = new ThreadLocal<MD5>(MD5.Create);


        private static readonly ThreadLocal<SHA256> sha256 = new ThreadLocal<SHA256>(SHA256.Create);



        public static byte[]? SafeCompleteSha256(string str ,Encoding? encoding =null)
        {
            if(encoding == null)
                encoding = Encoding.UTF8;
            try
            {
                return sha256.Value.ComputeHash(encoding.GetBytes(str));
            }catch(Exception ex)
            {
                logger.Error( $"HashUtil SafeCompleteSha256 Err:{str}", ex);
            }
            return null;
        }





        /// <summary>
        /// 计算文件MD5
        /// </summary>
        /// <param name="filePath">文件名</param>
        /// <param name="toUpper">是否大写</param>
        /// <returns>失败返回null</returns>
        public static byte[]? SafeCompleteMD5FromFile(string filePath)
        {
            try
            {
                return md5.Value.CompleteMD5FromFile(filePath);
            }
            catch (Exception ex)
            {

                logger.Error( $"HashUtil CompleteMD5WithFile Err:{filePath}", ex);
            }
            return null;

        }


        /// <summary>
        /// 从stream计算MD5
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="toUpper">是否大写</param>
        /// <returns></returns>
        public static byte[]? SafeCompleteMD5(Stream stream)
        {
            try
            {

                return md5.Value.ComputeHash(stream);

            }
            catch (Exception ex)
            {
                logger.Error( "HashUtil CompleteMD5FromStream Err", ex);
            }
            return null;

        }


        /// <summary>
        /// 从字节数组计算MD5
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[]? SafeCompleteMD5(byte[] bytes)
        {
            try
            {
                return md5.Value.ComputeHash(bytes);
            }
            catch (Exception ex)
            {
                logger.Error($"HashUtil CompleteMD5FromBytes Err:{bytes.ToHex()}" ,ex);
            }
            return null;

        }


        /// <summary>
        /// 从字符串数组计算MD5,默认UTF8
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[]? SafeCompleteMD5(string str , Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            try
            {
                return md5.Value.ComputeHash(encoding.GetBytes(str));
            }
            catch (Exception ex)
            {
                logger.Error($"HashUtil CompleteMD5FromBytes Err:{str}", ex);
            }
            return null;

        }
    }
}
