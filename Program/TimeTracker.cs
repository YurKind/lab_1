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

        public double GetSortingTime(SortDelegate sortDelegate, long[] array)
        {
            double result;
            Stopwatch stopwatch = new Stopwatch();
            
            for (int i = 0; i < iterations; i++)
            { 
                long[] tempArray = new long[array.Length];
                Array.Copy(array, tempArray, array.Length);

                stopwatch.Start();
                sortDelegate.Invoke(tempArray);
                stopwatch.Stop();
            }
            result = stopwatch.Elapsed.TotalMilliseconds / Iterations;
            return result;
        }
    }

    public delegate void SortDelegate(long[] array);
}