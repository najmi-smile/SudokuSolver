using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Implementations
{
    interface ISudokuBoardStrategy
    {
        int[,] Solve(int[,] sudokuBoard);
    }
}
