using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TLSP.Common.Extensions
{
    public static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UnsignedRightShift(this int signed, int places)
        {
            unchecked
            {
                return (int)((uint)signed >> places);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long UnsignedRightShift(this long signed, int places)
        {
            unchecked // just in case of unusual compiler switches; this is the default
            {
                return (long)((ulong)signed >> places);
            }
        }

    }
}
