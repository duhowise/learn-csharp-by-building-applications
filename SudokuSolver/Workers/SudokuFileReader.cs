using System;
using System.IO;
using System.Linq;

namespace SudokuSolver.Workers
{
    public class SudokuFileReader
    {
        public int[,] ReadFile(string fileName)
        {
            var sudokuBoard=new int[9,9];
            try
            {
                var boardFromFile = File.ReadLines(fileName);
                var row = 0;
                foreach (var fileLines in boardFromFile)
                {
                    var lineElements = fileLines.Split('|').Skip(1).Take(9).ToArray();
                    var column = 0;
                    foreach (var element in lineElements)
                    {
                        sudokuBoard[row, column] = element.Equals(" ") ? 0 : Convert.ToInt16(element);
                        column++;
                    }

                    row++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"something went wrong while reading the file\n{e.Message}");
            }

            return sudokuBoard;
        }
    }
}