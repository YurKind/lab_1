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
                    Console.WriteLine("Чао бамбина!");
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