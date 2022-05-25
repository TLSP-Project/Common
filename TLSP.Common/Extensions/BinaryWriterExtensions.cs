using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TLSP.Common.Extensions
{
    public static class BinaryWriterExtensions
    {
        public static void WriteStringWithShortLen(this BinaryWriter writer , string str ,Encoding? encoding = null)
        {
            if(encoding == null)
                encoding = Encoding.UTF8;
            writer.Write((ushort)str.Length);
            writer.Write(encoding.GetBytes(str));
        }
        public static void WriteStringWithByteLen(this BinaryWriter writer, string str, Encoding? encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            writer.Write((byte)str.Length);
            writer.Write(encoding.GetBytes(str));
        }
    }
}
