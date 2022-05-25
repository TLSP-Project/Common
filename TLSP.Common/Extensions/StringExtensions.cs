using System;
using System.Collections.Generic;
using System.Text;

namespace TLSP.Common.Extensions
{
    public static class StringExtensions
    {


        /// <summary>
        /// 将字符串转换为Uint32
        /// </summary>
        /// <param name="numStr"></param>
        /// <returns>失败则返回0</returns>
        public static uint SafeParseToUInt32(this string numStr)
        {
            uint result;
            uint.TryParse(numStr, out result);
            return result;
        }

        /// <summary>
        /// 将16进制字符串转换为bytes
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static byte[] HexToBytes(this string hex)
        {

            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {

                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch(Exception e)
                {
                    throw new FormatException("hex is not a valid hex number!",e);
                }
            }
            return bytes;
        }
    }
}
