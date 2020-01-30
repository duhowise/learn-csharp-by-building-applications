using System;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = { "This is the First Line", "This is the second Line", "Thus is the third line" };
            File.WriteAllLines("MyFirstFile.txt", lines);


            string[] fileContents = File.ReadAllLines("MyFirstFile.txt");
            foreach (var fileContent in fileContents)
            {
                Console.WriteLine(fileContent);
            }
        }

        static void ChangeNumber(ref int value)
        {
            
        }
    }
}
