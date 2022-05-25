using System;
using System.Collections.Generic;
using System.Text;

namespace TLSP.Common.Concurrent
{
    public class ConcurrentRandom
    {
        private readonly Random rand;

        private readonly object lockObj = new object();

        public ConcurrentRandom()
        {
            rand = new Random();
        }

        public ConcurrentRandom(int seed)
        {
            rand = new Random(seed);
        }

        public int Next()
        {
            lock (lockObj)
                return rand.Next();
        }


        public int Next(int maxValue)
        {
            lock (lockObj)
                return rand.Next(maxValue);
        }



        public int Next(int minValue, int maxValue)
        {
            lock (lockObj)
                return rand.Next(minValue, maxValue);
        }



        public double NextDouble()
        {
            lock (lockObj)
                return rand.NextDouble();
        }

        public void NextBytes(byte[] buffer)
        {
            lock (lockObj)
                rand.NextBytes(buffer);
        }
    }
}
