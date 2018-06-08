using SudokuSolver.contracts;
using SudokuSolver.Services;
using System;
using static System.Console;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                WriteLine("Please Enter the filename containing Sudoku Puzzle:\t");
                var filename = ReadLine();

                var sudokuBoard = sudokuFileReader.ReadFile(filename);
                sudokuBoardDisplayer.Display("initial State",sudokuBoard);

                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuBoardDisplayer.Display("Final State", sudokuBoard);

                WriteLine(isSudokuSolved
                    ? "You have successfully solved the puzzle" 
                    : "Your strategies are not intelegent enough to solve the sukodu puzzle ....");



            }
            catch(Exception ex)
            {
                WriteLine($"Sudoku puzzle cannot be solved as there is the problem \n{ex.Message}");
            }
        }
    }
}
