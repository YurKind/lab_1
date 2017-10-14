using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab1.Program
{
    public static class CommandService
    {
        private const long RandomDefaultSequenceLength = 2500;

        private static readonly string HelpInfoFilePath = @"../../Resources/help.txt";

        public static void DoTest(TimeTracker timeTracker, Dictionary<string, SortDelegate> allSorts)
        {
            try
            {
                Console.WriteLine("Итераций: {0}, Размер массива: {1}",
                    timeTracker.Iterations, timeTracker.Sequence.Length);

                foreach (var sort in allSorts)
                {
                    float currentSortTime = timeTracker.GetSortingTime(sort.Value, timeTracker.Sequence);
                    Console.WriteLine("{0}: {1} миллисекунд", sort.Key, currentSortTime);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Для начала теста требуется задать последовательность");
            }
        }

        public static void SetSequence(TimeTracker timeTracker, long[] values)
        {
            timeTracker.Sequence = values;
            Console.WriteLine("Последовательность установлена");
        }

        public static void SetRandomSequence(TimeTracker timeTracker, long value)
        {
            try
            {
                Random random = new Random();
                long arrayForSortingLength = value;

                timeTracker.Sequence = new long[arrayForSortingLength];
                for (int i = 0; i < arrayForSortingLength; i++)
                {
                    timeTracker.Sequence[i] = random.Next(-100, 100);
                }

                Console.WriteLine("Задана случайная последовательность длинной " + arrayForSortingLength);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Укажите длину последовательности");
            }
        }
        
        public static void PrintHelpInfo()
        {
            try
            {
                string[] helpInfo = File.ReadAllLines(HelpInfoFilePath);
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

        public static void SetNumberOfIterations(TimeTracker timeTracker, long value)
        {
            timeTracker.Iterations = (int) value;
            Console.WriteLine("Количество итераций: " + value);
        }

        public static string GetStringWithoutRedundantSpaces(string sourceString)
        {
            return Regex.Replace(sourceString, @"\s+", " ").Trim();
        }

        public static KeyValuePair<string, long[]> ReturnCommandAndValues(string commandLine)
        {
            commandLine = commandLine.ToLower();
            string commandLineWithoutRedundantSpaces = GetStringWithoutRedundantSpaces(commandLine);
            string[] commandLineElements = commandLineWithoutRedundantSpaces.Split(' ');

            long[] values = commandLineElements.Skip(1).Select(long.Parse).ToArray();

            return new KeyValuePair<string, long[]>(commandLineElements[0], values);
        }

        public static void CommandsHandler(KeyValuePair<string, long[]> commandAndTheirValues,
            TimeTracker timeTracker)
        {
            switch (commandAndTheirValues.Key)
            {
                case Commands.Test:
                    Dictionary<string, SortDelegate> allSorts = new Dictionary<string, SortDelegate>();
                    allSorts.Add("Bubble sort", Sort.BubbleSort);
                    allSorts.Add("Shell sort", Sort.ShellSort);
                    allSorts.Add("Default sort", Sort.DefaultSort);

                    DoTest(timeTracker, allSorts);
                    break;

                case Commands.Help:
                    PrintHelpInfo();
                    break;

                case Commands.Sequence:
                    SetSequence(timeTracker, commandAndTheirValues.Value);
                    break;

                case Commands.Random:
                    long sequnceLength;
                    try
                    {
                        sequnceLength = commandAndTheirValues.Value[0];
                    }
                    catch
                    {
                        sequnceLength = RandomDefaultSequenceLength;
                    }
                    SetRandomSequence(timeTracker, sequnceLength);
                    break;

                case Commands.Iterations:
                    try
                    {
                        SetNumberOfIterations(timeTracker, commandAndTheirValues.Value[0]);
                    }
                    catch
                    {
                        Console.WriteLine("Введите кол-во итераций");
                    }
                    break;

                default:
                    Console.WriteLine("Вы ввели несуществующую команду");
                    break;
            }
        }
    }
}