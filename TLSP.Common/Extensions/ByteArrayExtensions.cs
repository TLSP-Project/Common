using System;
using System.Collections.Generic;
using System.Text;

namespace TLSP.Common.Extensions
{
    public static class ByteArrayExtensions
    {


        public static byte[] Xor(this byte[] buffer, byte @byte)
        {
            byte[] result = new byte[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
                result[i] = (byte)(@byte ^ buffer[i]);

            return result;
        }
        public static byte[] Xor(this byte[] buffer , byte[] bytes)
        {
            byte[] result = new byte[buffer.Length];

            for (int i = 0; i < buffer.Length && i< bytes.Length; i++)
                result[i] = (byte)(bytes[i] ^ buffer[i]);

            return result;
        }
        /// <summary>
        /// 将bytes转换为HEX字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="toUpper">是否大写</param>
        /// <returns></returns>
        public static string ToHex(this byte[] bytes, bool toUpper = false)
        {
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                ret.AppendFormat(toUpper ? "{0:X2}" : "{0:x2}", b);
            }
            var hex = ret.ToString();
            return hex;
        }
        public static string ToBinary(this byte[] buffer)
        {
            StringBuilder sb = new StringBuilder(buffer.Length * 8);
            foreach (var item in buffer)
            {
                var itemBinary = Convert.ToString(item, 2);

                for (int i = 0; i < 8 - itemBinary.Length; i++)
                    sb.Append('0');

                sb.Append(itemBinary);
            }
            return sb.ToString();
        }

    }
}
