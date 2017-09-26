using System;

namespace lab1.Properties
{
    public class Sort
    {
        public static void DefaultSort(long[] array)
        {
            Array.Sort(array);
        }

        public static void BubbleSort(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        long temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void ShellSort(long[] array)
        {
            int j;
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < array.Length - step; i++)
                {
                    j = i;
                    while (j >= 0 && array[j] > array[j + step])
                    {
                        long tmp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
    }
}