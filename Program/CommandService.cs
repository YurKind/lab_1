using System;
using System.Collections.Generic;
using System.IO;

namespace lab1.Properties
{
    public static class CommandService
    {
        public static void DoTest(Comparator comparator, Dictionary<string, SortDelegate> allSorts)
        {
            Console.WriteLine("Итераций: {0}, Размер массива: {1}",
                comparator.Iterations, comparator.Sequence.Length);
            try
            {
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

        public static void SetSequence(Comparator comparator, string[] command)
        {
            comparator.Sequence = new long[command.Length - 1];

            try
            {
                for (int i = 0; i < command.Length - 1; i++)
                {
                    comparator.Sequence[i] = Convert.ToInt32(command[i + 1]);
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

        public static void SetRandomSequence(Comparator comparator, string[] command)
        {
            try
            {
                Random random = new Random();

                long arrayLength = Convert.ToInt32(command[1]);
                comparator.Sequence = new long[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    comparator.Sequence[i] = random.Next(-100, 100);
                }

                Console.WriteLine("Задана случайная последовательность длинной " + arrayLength);
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

        public static void SetNumberOfIterations(Comparator comparator, string[] command)
        {
            try
            {
                comparator.Iterations = Convert.ToInt32(command[1]);
                Console.WriteLine("Количество итераций: " + command[1]);
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
    }
}