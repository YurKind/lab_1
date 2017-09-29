using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab1.Properties
{
    public static class CommandService
    {
        public static void DoTest(Comparator comparator, Dictionary<string, SortDelegate> allSorts)
        {
            try
            {
                Console.WriteLine("Итераций: {0}, Размер массива: {1}",
                    comparator.Iterations, comparator.Sequence.Length);

                foreach (var sort in allSorts)
                {
                    long currentSortTime = comparator.Compare(sort.Value, comparator.Sequence);
                    Console.WriteLine("{0}: {1} миллисекунд", sort.Key, currentSortTime);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Для начала теста требуется задать последовательность");
            }
        }

        public static void SetSequence(Comparator comparator, long[] values)
        {
            comparator.Sequence = new long[values.Length];

            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    comparator.Sequence[i] = values[i];
                }
                Console.WriteLine("Последовательность установлена");
            }
            catch (FormatException)
            {
                comparator.Sequence = null;
                Console.WriteLine("Требуется вводить только числа через пробел");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели недопустимо малое или недопустимо большое число");
            }
        }

        public static void SetRandomSequence(Comparator comparator, long value)
        {
            try
            {
                Random random = new Random();

                long arrayForSortingLength = value;

                comparator.Sequence = new long[arrayForSortingLength];
                for (int i = 0; i < arrayForSortingLength; i++)
                {
                    comparator.Sequence[i] = random.Next(-100, 100);
                }

                Console.WriteLine("Задана случайная последовательность длинной " + arrayForSortingLength);
            }
            catch (FormatException)
            {
                Console.WriteLine("Длина последовательности указана неверно");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Укажите длину последовательности");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели недопустимо малое или недопустимо большое число");
            }
        }

        public static void PrintHelpInfo(string filePath)
        {
            try
            {
                string[] helpInfo = FileReader.ReturnFileContent(filePath);
                foreach (string info in helpInfo)
                {
                    Console.WriteLine(info);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Файл {0} не найден", ex.FileName);
            }
        }

        public static void SetNumberOfIterations(Comparator comparator, long value)
        {
            try
            {
                comparator.Iterations = (int) value;
                Console.WriteLine("Количество итераций: " + value);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели недопустимо малое или недопустимо большое число");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Введите кол-во итераций");
            }
        }

        public static string GetStringWithoutRedundantSpaces(string sourceString)
        {
            return Regex.Replace(sourceString, @"\s+", " ").Trim();
        }

        public static KeyValuePair<string, long[]> ReturnCommandAndValues(string commandLine)
        {
            string commandLineWithoutRedundantSpaces = GetStringWithoutRedundantSpaces(commandLine);
            string[] commandLineElements = commandLineWithoutRedundantSpaces.Split(' ');

            long[] values = commandLineElements.Skip(1).Select(long.Parse).ToArray();

            return new KeyValuePair<string, long[]>(commandLineElements[0], values);
        }
    }
}