using System;
using System.Diagnostics;

namespace lab1.Properties
{
    public class Comparator
    {
        private int iterations = 100;
        private int[] sequence;

        public int Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }

        public long[] Sequence { get; set; }

        public long Compare(SortDelegate sortDelegate, long[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < iterations; i++)
            {
                long[] tempArray = array;
                stopwatch.Start();
                sortDelegate.Invoke(tempArray);
                stopwatch.Stop();
            }

            return stopwatch.ElapsedMilliseconds / Iterations;
        }
    }

    public delegate void SortDelegate(long[] array);
}