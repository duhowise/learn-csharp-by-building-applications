using System;
using System.Diagnostics;
using System.IO;

namespace WordUnscrambler.Workers
{
    public class FileReader
    {
        public string[] Read(string fileName)
        {
            try
            {
                var fileContent = File.ReadAllLines(fileName);
                return fileContent;
            }
            catch (Exception e)
            {
               throw new Exception(e.Message,e);
            }

        }
    }
}