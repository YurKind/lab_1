using System;
using System.Diagnostics;

namespace lab1.Properties
{
    public class Comparator
    {
        private static int iterations = 100;
        private static int[] sequence;


        public static int Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }

        public static long[] Sequence { get; set; }

        public static string Test(SortDelegate sortDelegate, long[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < iterations; i++)
            {
                long[] tempArray = array;
                stopwatch.Start();
                sortDelegate.Invoke(tempArray);
                stopwatch.Stop();
            }
            
            return (stopwatch.ElapsedMilliseconds/Iterations*1000).ToString();
        }
    }

    public delegate void SortDelegate(long[] array);
}