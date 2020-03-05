using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Workers;

namespace SudokuSolver.Strategies
{
    public class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuMapper sudokuMapper, SudokuBoardStateManager sudokuBoardStateManager)
        {
            _sudokuMapper = sudokuMapper;
            _sudokuBoardStateManager = sudokuBoardStateManager;
        }

        public bool Solve(int[,] sudokuBoard)
        {
            var strategies = new List<ISudokuStrategy>
            {
                new SimpleMarkUpStrategy(_sudokuMapper),
                new NakedPairsStrategy(_sudokuMapper)
                
            };
            var currentState = _sudokuBoardStateManager.GenerateState(sudokuBoard);
            var nextState = _sudokuBoardStateManager.GenerateState(strategies.First().Solve(sudokuBoard));
            while (!_sudokuBoardStateManager.IsSolved(sudokuBoard) && currentState != nextState)
            {
                currentState = nextState;
                foreach (var sudokuStrategy in strategies)
                {
                    nextState = _sudokuBoardStateManager.GenerateState(sudokuStrategy.Solve(sudokuBoard));
                }
            }

            return _sudokuBoardStateManager.IsSolved(sudokuBoard);
        }

        
    }
}