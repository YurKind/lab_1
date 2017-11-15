using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace lab1.Program
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            CommandService.SetCharacterLimit(1000000);

            Console.WriteLine("Привет! Я жду команд!");
            try
            {
                if (args.Length > 1)
                {
                    Console.WriteLine("Превышено число параметров");
                }
                //else if (args.Length == 1)
                //{
                //    //SortsComparator.Start(args[0]);
                //}
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