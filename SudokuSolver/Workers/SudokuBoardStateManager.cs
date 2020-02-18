using System;
using System.Text;

namespace SudokuSolver.Workers
{
    public class SudokuBoardStateManager
    {
        public string GenerateState(int[,]sudokuBoard)
        {
            var key=new StringBuilder();
            for (var row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (var column = 0; column < sudokuBoard.GetLength(1); column++)
                {
                    key.Append(sudokuBoard[row, column]);
                }
            }
            return key.ToString();
        }


        public bool IsSolved(int[,]sudokuBoard)
        {
            for (var row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (var column = 0; column < sudokuBoard.GetLength(1); column++)
                {
                    if (sudokuBoard[row,column]==0||sudokuBoard[row,column].ToString().Length>1)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}