using System;
using System.Collections.Generic;
using System.Text;
using TLSP.Common.Extensions;
namespace TLSP.Common.Utilities
{

    public static class TimeHelper
    {
        private static readonly DateTime StartTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

        public static int GetCurrentTimeStamp() => (int)(DateTime.Now - StartTime).TotalSeconds;

        public static long GetCurrentTimeStampLong() => (long)(DateTime.Now - StartTime).TotalMilliseconds;
    }
}
