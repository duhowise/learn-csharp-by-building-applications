using System;
using System.Linq;
using SudokuSolver.Workers;

namespace SudokuSolver.Strategies
{
    public class SimpleMarkUpStrategy:ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public SimpleMarkUpStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }
        public int[,] Solve(int[,] sudokuBoard)
        {
            for (var row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (var column = 0; column < sudokuBoard.GetLength(1); column++)
                {
                    if (sudokuBoard[row, column] == 0 || sudokuBoard[row, column].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndColumn = GetPossibilitiesInRowAndColumn(sudokuBoard, row, column);
                        var possibilitiesInBlock= GetPossibilitiesBlock(sudokuBoard, row, column);
                        sudokuBoard[row, column] = GetPossibilityIntersection(sudokuBoard, row, column);
                        
                    }
                }
            }
            return sudokuBoard;
        }

        private int GetPossibilitiesInRowAndColumn(int[,] sudokuBoard, in int givenRow, in int givenColumn)
        {
            var possibilities = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            for (var column = 0; column < 9; column++)
            {
                if (IsValidSingle(sudokuBoard[givenRow, column]))
                {
                    possibilities[sudokuBoard[givenRow, column] - 1] = 0;
                }
            }
            for (var row = 0; row < 9; row++)
            {
                if (IsValidSingle(sudokuBoard[row, givenColumn]))
                {
                    possibilities[sudokuBoard[row, givenColumn] - 1] = 0;
                }
            }

            return Convert.ToInt32(string.Join(String.Empty, possibilities.Select(x => x).Where(x => x != 0)));
        }

        

        private int GetPossibilitiesBlock(int[,] sudokuBoard, in int givenRow, in int givenColumn)
        {
            var possibilities = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(givenRow, givenColumn);
            for (var row = sudokuMap.StartRow; row <= sudokuMap.StartRow+2; row++)
            {
                for (var column = sudokuMap.StartColumn; column <= sudokuMap.StartColumn + 2; column++)
                {
                    if (IsValidSingle(sudokuBoard[row, column]))
                    {
                        possibilities[sudokuBoard[row, column] - 1] = 0;
                    }
                }
            }
            return Convert.ToInt32(string.Join(String.Empty,possibilities.Select(x=>x).Where(x=>x!=0)));
        }

        private int GetPossibilityIntersection(int[,] sudokuBoard, in int possibilitiesInRowAndColumn, in int possibilitiesInBlock)
        {
            var possibilitiesInRowAndColumnCharacterArray = possibilitiesInRowAndColumn.ToString().ToCharArray();
            var possibilitiesInBlockCharacterArray = possibilitiesInBlock.ToString().ToCharArray();
          var  possibilitiesSubset =
                possibilitiesInRowAndColumnCharacterArray.Intersect(possibilitiesInBlockCharacterArray);
          return Convert.ToInt32(string.Join(string.Empty, possibilitiesSubset));
        }
        private bool IsValidSingle(int sudokuCellValue)
        {
            return sudokuCellValue != 0 && sudokuCellValue.ToString().Length ==1;
        }
    }
}