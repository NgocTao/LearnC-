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
    }
}


