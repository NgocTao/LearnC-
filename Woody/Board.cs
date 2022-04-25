using System;
using System.Collections.Generic;
using System.Text;

namespace Woody
{
    public class Board
    {
        public int Colums = 10;
        public int Rows = 10;
        public Block[,] DataCell;

        public Board()
        {
            DataCell = new Block[Rows, Colums];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    DataCell[i, j] = new Block();
                    DataCell[i, j].value = 0;
                }
            }
        }
        public void SetBlockValueBoard(int row, int colum, int value)
        {
            DataCell[row, colum].value = value;
        }
        public void ShowBoard()
        {
            string str = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    str += DataCell[i, j].value.ToString() + " ";
                }
                str += "\n";
            }
            Console.WriteLine(str);
        }
        public bool CheckLocation(Puzzle puzzle, int selectRow, int selectCol)
        {
            bool result = true;
            for (int r = 0; r < puzzle.Rows; r++)
            {
                for (int c = 0; c < puzzle.Colums; c++)
                {
                    if (puzzle.BlockData[r, c].value == 1)
                    {
                        int realRow = r - puzzle.MaxRow + selectCol;
                        int realCol = c - puzzle.MinCot + selectCol;
                        if (realRow < 0 || realRow > 9 || realCol < 0 || realCol > 9)
                        {
                            return false;
                        }
                        if(DataCell[realRow,realCol].value == 1)
                        {
                            return false;
                        }    
                    }
                }
            }
            return result;
        }
        public void InsertPuzzle(Puzzle puzzle, int selectRow, int selectCol)
        {
            for (int r = 0; r < puzzle.Rows; r++)
            {
                for (int c = 0; c < puzzle.Colums; c++)
                {
                    int realRow = r - puzzle.MaxRow + selectCol;
                    int realCol = c - puzzle.MinCot + selectCol;
                    r = realRow;
                    c = realCol;
                    puzzle.BlockData[r,c].value = DataCell[realRow,realCol].value;
                }
            }
        }
    }
}


