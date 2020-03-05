using System;
using SudokuSolver.Strategies;
using SudokuSolver.Workers;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var mapper=new SudokuMapper();
                var boardStateManager = new SudokuBoardStateManager();
                var solverEngine=new SudokuSolverEngine(mapper, boardStateManager);
                var fileReader=new SudokuFileReader();
                var displayer=new SudokuBoardDisplayer();
                Console.WriteLine("Please enter the filename containing the sudoku puzzle");
                var fileName = Console.ReadLine();

                var sudokuBoard = fileReader.ReadFile(fileName);
                displayer.Display("Initial State",sudokuBoard);
                var isSolved = solverEngine.Solve(sudokuBoard);
                displayer.Display("Final State",sudokuBoard);

                Console.WriteLine(isSolved ? "You have successfully solved the sudoku puzzle":"Unfortunately puzzle not solved");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sudoku puzzle cannot be solved because there was an error: {e.Message}");

            }
        }
    }
}
