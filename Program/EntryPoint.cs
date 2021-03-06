﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace lab1.Program
{
    public class EntryPoint
    {
        private const int CHARACTER_LIMIT = 1000000;

        public static void Main(string[] args)
        {
            CommandService.SetCharacterLimit(CHARACTER_LIMIT);

            Console.WriteLine("Привет! Я жду команд!");
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
            catch
            {
                Console.WriteLine("Что-то пошло не так...");
            }
        }
    }
}