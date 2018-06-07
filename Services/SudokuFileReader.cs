using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace SudokuSolver.Services
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] board = new int[9, 9];
            try
            {
                var sudokuFile = File.ReadAllLines(filename);
                Write(sudokuFile);

            }
            catch(Exception ex)
            {
                throw new Exception($"There is something wrong with the file: {ex.Message}");
            }
            return board;
        }
    }
}
