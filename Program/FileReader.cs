using System;
using System.IO;

namespace lab1.Properties
{
    public class FileReader
    {
        public static string[] ReturnFileContent(string filename)
        {      
             return File.ReadAllLines(filename);
        }
    }
}