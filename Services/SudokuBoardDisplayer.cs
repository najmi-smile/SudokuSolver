using System;
using System.Collections.Generic;
using static System.Console;

namespace SudokuSolver.Services
{
    class SudokuBoardDisplayer
    {
        public void Display(string title, int[,] sudokuBoard)
        {
            if (!title.Equals(string.Empty)) WriteLine("{0}{1}", title, Environment.NewLine);
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                Write("|");
                for(int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    WriteLine($"{sudokuBoard[row, col]}|");
                }
                WriteLine();
            }
            WriteLine();

        }
    }
}
