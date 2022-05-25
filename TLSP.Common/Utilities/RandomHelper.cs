using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TLSP.Common.Concurrent;

namespace TLSP.Common.Utilities
{
    public static class RandomHelper
    {
        private static readonly ConcurrentRandom baseRand = new ConcurrentRandom();

        private static readonly ThreadLocal<Random> rand = new ThreadLocal<Random>(() => new Random(baseRand.Next()));

        public static int NextInt() => rand.Value.Next();


        public static int NextInt(int maxValue) => rand.Value.Next(maxValue);


        public static int NextInt(int minValue, int maxValue) => rand.Value.Next(minValue, maxValue);


        public static double NextDouble() => rand.Value.NextDouble();

        public static void NextBytes(byte[] buffer) => rand.Value.NextBytes(buffer);

        public static string NextString(int len , string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            StringBuilder @string = new StringBuilder(len);
            int max = chars.Length - 1;
            for (int i = 0; i < len; i++)
            {
                @string.Append(chars[NextInt(max)]);
            }
            return @string.ToString();
        }
    }
}
