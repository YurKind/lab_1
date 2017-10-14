using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace lab1.Program
{
    public class TimeTracker
    {
        private int iterations = 100;
        private long[] sequence;

        public int Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }

        public long[] Sequence { get; set; }

        public float GetSortingTime(SortDelegate sortDelegate, long[] array)
        {
            float result;
            Stopwatch stopwatch = new Stopwatch();
            
            for (int i = 0; i < iterations; i++)
            {
                long[] tempArray = array;
                stopwatch.Start();
                sortDelegate.Invoke(tempArray);
                stopwatch.Stop();
            }
            result = (float) stopwatch.ElapsedMilliseconds / Iterations;
            return result <= 0.0 ? (float) 0.0001 : result;
        }
    }

    public delegate void SortDelegate(long[] array);
}