using System;

namespace SudokuSolver.Workers
{
    public class SudokuBoardDisplayer
    {
        public void Display(string title, int[,] sudokuBoard)
        {
            if (!string.IsNullOrWhiteSpace(title)) Console.WriteLine($"{title}{Environment.NewLine}");
            for (var row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                Console.Write("|");
                for (var column = 0; column < sudokuBoard.GetLength(1); column++)
                {
                    Console.WriteLine($"{sudokuBoard[row, column]}|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}