using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using lab1.Properties;

namespace lab1.Program
{
    public static class SortsComparator
    {
        private const string HelpInfoFilePath = @"..\..\Resources\help.txt";

        private static Comparator comparator = new Comparator();

        private static bool isProgramRunning = true;

        private static KeyValuePair<string, long[]> commandAndTheirValues;

        public static void Start(string fileName)
        {
            string[] fileLines = FileReader.ReturnFileContent(fileName);
            Dictionary<string, long[]> commandsAndTheirValues = fileLines
                .TakeWhile(line => !line.Equals(Commands.Test))
                .Select(CommandService.ReturnCommandAndValues)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            
            
        }

        public static void Start()
        {
            while (isProgramRunning)
            {
                try
                {
                    commandAndTheirValues = CommandService.ReturnCommandAndValues(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение");
                    continue;
                }

                switch (commandAndTheirValues.Key)
                {
                    case Commands.Test:
                        Dictionary<string, SortDelegate> allSorts = new Dictionary<string, SortDelegate>();
                        allSorts.Add("Bubble sort", Sort.BubbleSort);
                        allSorts.Add("Shell sort", Sort.ShellSort);
                        allSorts.Add("Default sort", Sort.DefaultSort);

                        CommandService.DoTest(comparator, allSorts);
                        break;

                    case Commands.Help:
                        CommandService.PrintHelpInfo(HelpInfoFilePath);
                        break;

                    case Commands.Sequence:
                        CommandService.SetSequence(comparator, commandAndTheirValues.Value);
                        break;

                    case Commands.Random:
                        CommandService.SetRandomSequence(comparator, commandAndTheirValues.Value[0]);
                        break;

                    case Commands.Iterations:
                        CommandService.SetNumberOfIterations(comparator, commandAndTheirValues.Value[0]);
                        break;

                    case Commands.Exit:
                        isProgramRunning = false;
                        break;

                    default:
                        Console.WriteLine("Вы ввели несуществующую команду");
                        break;
                }
            }
        }
    }
}