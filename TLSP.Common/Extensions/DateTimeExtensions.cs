using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLSP.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);

        /// <summary>
        /// 将DateTime转换为时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="milliSeconds">是否转化为13位毫秒时间戳</param>
        /// <returns></returns>
        public static int ToTimeStamp(this DateTime dateTime)
        {
            return (int)dateTime.ToUniversalTime().Subtract(UnixEpoch).TotalSeconds;
        }

        public static long ToLongTimeStamp(this DateTime dateTime)
        {
            return (long)dateTime.ToUniversalTime().Subtract(UnixEpoch).TotalMilliseconds;
        }
    }
}
