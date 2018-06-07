using SudokuSolver.DatMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services
{
    class SudokuMapper
    {
        public SudokuBoardMap Find(int givenRow, int givenCol)
        {
            SudokuBoardMap sudokuBoardMap = new SudokuBoardMap();
            //  1st block row
            if ((givenRow >= 0 && givenRow <= 2) && (givenCol >= 0 && givenCol <= 2))
            {
                sudokuBoardMap.StartRow = 0;
                sudokuBoardMap.StartCol = 0;
            }
            else if ((givenRow >= 0 && givenRow <= 2) && (givenCol >= 3 && givenCol <= 5))
            {
                sudokuBoardMap.StartRow = 0;
                sudokuBoardMap.StartCol = 3;
            }
            else if ((givenRow >= 0 && givenRow <= 2) && (givenCol >= 6 && givenCol <= 8))
            {
                sudokuBoardMap.StartRow = 0;
                sudokuBoardMap.StartCol = 6;
            }

            //  2nd block row
            if ((givenRow >= 3 && givenRow <= 5) && (givenCol >= 0 && givenCol <= 2))
            {
                sudokuBoardMap.StartRow = 3;
                sudokuBoardMap.StartCol = 0;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenCol >= 3 && givenCol <= 5))
            {
                sudokuBoardMap.StartRow = 3;
                sudokuBoardMap.StartCol = 3;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenCol >= 6 && givenCol <= 8))
            {
                sudokuBoardMap.StartRow = 3;
                sudokuBoardMap.StartCol = 6;
            }

            //   3rd block row
            if ((givenRow >= 6 && givenRow <= 8) && (givenCol >= 0 && givenCol <= 2))
            {
                sudokuBoardMap.StartRow = 6;
                sudokuBoardMap.StartCol = 0;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenCol >= 3 && givenCol <= 5))
            {
                sudokuBoardMap.StartRow = 6;
                sudokuBoardMap.StartCol = 3;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenCol >= 6 && givenCol <= 8))
            {
                sudokuBoardMap.StartRow = 6;
                sudokuBoardMap.StartCol = 6;
            }
            return sudokuBoardMap;
        }
    }
}
