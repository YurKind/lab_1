using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace lab1.Properties
{
    public static class SortsComparator
    {
        private const string HelpInfoFilePath = @"..\..\Resources\help.txt";

        private static Comparator comparator = new Comparator();

        public static void Start()
        {
            while (true)
            {
                String commandLine = Console.ReadLine();
                string[] command = commandLine.Split(' ');

                switch (command[0])
                {
                    case Commands.test:
                        Dictionary<string, SortDelegate> allSorts = new Dictionary<string, SortDelegate>();
                        allSorts.Add("Bubble sort", Sort.BubbleSort);
                        allSorts.Add("Shell sort", Sort.ShellSort);
                        allSorts.Add("Default sort", Sort.DefaultSort);

                        CommandService.DoTest(comparator, allSorts);
                        break;

                    case Commands.help:
                        CommandService.PrintHelpInfo(HelpInfoFilePath);
                        break;

                    case Commands.sequence:
                        CommandService.SetSequence(comparator, command);
                        break;

                    case Commands.random:
                        CommandService.SetRandomSequence(comparator, command);
                        break;

                    case Commands.iterations:
                        CommandService.SetNumberOfIterations(comparator, command);
                        break;

                    case Commands.exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Вы ввели несуществующую команду");
                        break;
                }
            }
        }
    }
}