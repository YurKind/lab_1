using System;
using System.Diagnostics;

namespace lab1.Program
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Привет! Я жду команд!");
            try
            {
                if (args.Length > 1)
                {
                    Console.WriteLine("Превышено число параметров");
                }
                else if (args.Length == 1)
                {
                    SortsComparator.Start(args[0]);
                }
                else
                {
                    SortsComparator.Start();
                }
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так...");
            }
        }
    }
}