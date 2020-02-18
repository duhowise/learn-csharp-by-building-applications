namespace SudokuSolver.Workers
{
    public class SudokuMapper
    {
        public SudokuMap Find(int givenRow, int givenColumn)
        {
            var sudokuMap=new SudokuMap();
            if ((givenRow >= 0 && givenRow <= 2)&&(givenColumn >= 0 && givenColumn <= 2))
            {
                sudokuMap.StartColumn = 0;
                sudokuMap.StartRow = 0;

            }else if ((givenRow >= 0 && givenRow <= 2)&&(givenColumn >= 3 && givenColumn <= 5))
            {
                sudokuMap.StartColumn = 0;
                sudokuMap.StartRow = 3;

            }else if ((givenRow >= 0 && givenRow <= 2)&&(givenColumn >= 6 && givenColumn <= 8))
            {
                sudokuMap.StartColumn = 0;
                sudokuMap.StartRow = 6;

            }else if ((givenRow >= 3 && givenRow <= 5)&&(givenColumn >= 6 && givenColumn <= 8))
            {
                sudokuMap.StartColumn = 3;
                sudokuMap.StartRow = 0;

            }else if ((givenRow >= 3 && givenRow <= 5)&&(givenColumn >= 3 && givenColumn <= 5))
            {
                sudokuMap.StartColumn = 3;
                sudokuMap.StartRow = 3;

            }else if ((givenRow >= 6 && givenRow <= 8)&&(givenColumn >= 0 && givenColumn <= 2))
            {
                sudokuMap.StartColumn = 6;
                sudokuMap.StartRow = 0;

            }
            else if ((givenRow >= 6 && givenRow <= 8)&&(givenColumn >= 3 && givenColumn <= 5))
            {
                sudokuMap.StartColumn = 6;
                sudokuMap.StartRow = 3;

            }else if ((givenRow >= 6 && givenRow <= 8)&&(givenColumn >= 6 && givenColumn <= 8))
            {
                sudokuMap.StartColumn = 6;
                sudokuMap.StartRow = 6;

            }

            return sudokuMap;
        }
    }

    public class SudokuMap
    {
        public int StartColumn { get; set; }
        public int StartRow { get; set; }
    }
}