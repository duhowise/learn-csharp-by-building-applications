namespace SudokuSolver.Strategies
{
    public interface ISudokuStrategy
    {
        int[,] Solve(int[,] sudokuBoard);

    }
}