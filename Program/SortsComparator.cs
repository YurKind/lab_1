using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab1.Program
{
    public static class SortsComparator
    {
        private static TimeTracker _timeTracker = new TimeTracker();

        private static bool isProgramRunning = true;

        private static KeyValuePair<string, long[]> commandAndTheirValues;

        //public static void Start(string filePath)
        //{
        //    string[] fileLines;
        //    try
        //    {
        //        fileLines = File.ReadAllLines(filePath);
        //    }
        //    catch (FileNotFoundException ex)
        //    {
        //        Console.Write("Файл {0} не найден", ex.FileName);
        //        return;
        //    }


        //    //Dictionary<string, long[]> commandsAndTheirValues = fileLines
        //    //    .Take(fileLines.Length)
        //    //    .Select(CommandService.ReturnCommandAndValues)
        //    //    .ToDictionary(pair => pair.Key, pair => pair.Value);

        //    IDictionary<string, long[]> commandsAndTheirValues = new IDictionary<string, long[]>();
        //    foreach(string line in fileLines)
        //    {
        //        KeyValuePair<string, long[]> tempValues = CommandService.GetCommandAndValue(line);
        //        commandsAndTheirValues.Add(tempValues.Key, tempValues.Value);
        //    }

        //    if (commandsAndTheirValues.Count() == 0)
        //    {
        //        Console.WriteLine("Проверьте корректность заданных в файле");
        //    }
        //    else
        //    {
        //        foreach (var pair in commandsAndTheirValues)
        //        {
        //            CommandService.CommandsHandler(pair, _timeTracker);
        //        }
        //    }
        //}

        public static void Start()
        {
            while (isProgramRunning)
            {
                try
                {
                    Console.Write(" > ");
                    commandAndTheirValues = CommandService.GetCommandAndValue(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                if (commandAndTheirValues.Key == Commands.Exit)
                {
                    Console.WriteLine("Чао");
                    isProgramRunning = false;
                }
                else
                {
                    CommandService.CommandsHandler(commandAndTheirValues, _timeTracker);
                }
            }
        }
    }
}