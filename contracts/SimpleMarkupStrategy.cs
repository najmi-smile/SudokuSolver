﻿using SudokuSolver.Implementations;
using SudokuSolver.Services;
using System;
using System.Linq;

namespace SudokuSolver.contracts
{
    class SimpleMarkupStrategy : ISudokuBoardStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public SimpleMarkupStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }
        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(sudokuBoard, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(sudokuBoard, row, col);
                        sudokuBoard[row, col] = GetPossibilityIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                    }
                }
            }
            return sudokuBoard;
        }
        private object GetPossibilitiesInRowAndCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int row = 0; row < 9; row++) if (IsValidSingle(sudokuBoard[row, givenCol])) possibilities[sudokuBoard[row, givenCol] - 1] = 0;
            for (int col = 0; col < 9; col++) if (IsValidSingle(sudokuBoard[givenRow, col])) possibilities[sudokuBoard[givenRow, col] - 1] = 0;
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private bool IsValidSingle(int cellDigit)
        {
            return cellDigit != 0 && cellDigit.ToString().Length < 2;
        }

        private object GetPossibilitiesInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (IsValidSingle(sudokuBoard[row, givenCol])) possibilities[sudokuBoard[row, givenCol] - 1] = 0;
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));

        }
        private int GetPossibilityIntersection(object possibilitiesInRowAndCol, object possibilitiesInBlock)
        {
            var possiblilitiesInRowAndColCharArray = possibilitiesInRowAndCol.ToString().ToCharArray();
            var possibilitesInBlockCharArray = possibilitiesInBlock.ToString().ToCharArray();
            var possibilitiesSubset = possiblilitiesInRowAndColCharArray.Intersect(possibilitesInBlockCharArray);
            return Convert.ToInt32(string.Join(string.Empty, possibilitiesSubset));
        }


    }
}
