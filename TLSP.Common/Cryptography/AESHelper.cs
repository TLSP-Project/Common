using System;
using System.Security.Cryptography;

namespace TLSP.Common.Cryptography
{
    public class AESHelper
    {
        /// <summary>
        /// 获取Cryptor实例
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        public static ICryptoTransform getCipherInstance(byte[] Key, bool encrypt = true)
        {
            if (Key.Length < 16)
            {
                //补全128bit
                Array.Resize(ref Key, 16);
            }
            else if (Key.Length < 24)
            {
                //补全192bit
                Array.Resize(ref Key, 24);
            }
            else if (Key.Length < 32)
            {
                //补全256bit
                Array.Resize(ref Key, 32);
            }
            else
            {
                //截取256bit
                Array.Resize(ref Key, 32);
            }

            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.ECB;
            rijndaelCipher.KeySize = 128;
            rijndaelCipher.Key = Key;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.BlockSize = 128;
            return encrypt ? rijndaelCipher.CreateEncryptor() : rijndaelCipher.CreateDecryptor();
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] encrypt(byte[] key, byte[] source)
        {
            ICryptoTransform crypto = getCipherInstance(key, true);
            return crypto.TransformFinalBlock(source, 0, source.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] decrypt(byte[] key, byte[] source)
        {
            ICryptoTransform crypto = getCipherInstance(key, false);
            return crypto.TransformFinalBlock(source, 0, source.Length);
        }
    }
}
