using System;
using System.IO;

namespace lab1.Properties
{
    public class FileReader
    {
        public static void readFile(string filename)
        {
            try
            {
                StreamReader reader = File.OpenText(filename);
                string line = "";
                while (line != null)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Файл {0} не найден", ex.FileName);
            }
        }
    }
}