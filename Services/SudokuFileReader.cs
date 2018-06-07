using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                int row = 0;
                foreach(var line in sudokuFile)
                {
                    // spliting the line to extract the elements in between the || 
                    string[] splitSudkoLine = line.Split('|').Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach(var element in splitSudkoLine)
                    {
                        //   populating the board
                        board[row, col] = element.Equals(" ") ? 0 : Convert.ToInt16(element);
                        col++;
                    }
                    row++;
                }

            }
            catch(Exception ex)
            {
                throw new Exception($"There is something wrong with the file: {ex.Message}");
            }
            return board;
        }
    }
}
