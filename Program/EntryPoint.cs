using System;
using System.Diagnostics;
using System.Threading;
using lab1.Program;

namespace lab1.Properties
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    Console.WriteLine("Превышено число параметров");
                }
                else
                {
                    SortsComparator.Start();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Что-то пошло не так...");
            }
        }
    }
}