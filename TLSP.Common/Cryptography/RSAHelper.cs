using System;
using System.Collections.Generic;
using System.Text;

namespace TLSP.Common.Cryptography
{
    public class RSAHelper
    {
        /// <summary>
        /// KEY 结构体
        /// </summary>
        public struct RSAKEY
        {
            /// <summary>
            /// 公钥
            /// </summary>
            public byte[] PublicKey
            {
                get;
                set;
            }
            /// <summary>
            /// 私钥
            /// </summary>
            public byte[] PrivateKey
            {
                get;
                set;
            }
        }


        /// <summary>
        /// 生成密钥对
        /// </summary>
        /// <returns></returns>
        public static RSAKEY GetKey()
        {
            RSA rsa = new RSA(1024);

            RSAKEY item = new RSAKEY()
            {
                PublicKey = rsa.ExportKey(false),
                PrivateKey = rsa.ExportKey(true)
            };
            return item;
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] publickey, byte[] content)
        {
            RSA rsa = new RSA(RSA_PEM.FromJavaKey(publickey));
            return rsa.Encode(content);
        }

        public static byte[] RSAEncrypt(string publickey, byte[] content)
        {
            RSA rsa = new RSA(RSA_PEM.FromJavaKeyBase64(publickey));
            return rsa.Encode(content);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] privateKey, byte[] content)
        {
            RSA rsa = new RSA(RSA_PEM.FromJavaKey(privateKey));
            return rsa.DecodeOrNull(content);
        }

        public static byte[] RSADecrypt(string privateKey, byte[] content)
        {
            RSA rsa = new RSA(RSA_PEM.FromJavaKeyBase64(privateKey));
            return rsa.DecodeOrNull(content);
        }
    }
}
