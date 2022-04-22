using System;
using System.Collections.Generic;
using System.Text;

namespace Woody
{
    public class PuzzleData
    {
        public string ID;
        public int[] Array;

    }

    public class Puzzle
    {
        public int Colums = 5;
        public int Rows = 5;
        public Block[,] DataCell;


        public Puzzle()
        {
        }

        public void SetValuePuzz(int row, int colum, int value)
        {
            DataCell[row, colum].value = value;
        }
        public void ShowPuzz()
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
        public Puzzle (PuzzleData dataPuzzle)
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
            for (int i = 0; i < dataPuzzle.Array.Length ; i++)
            {
                int R = dataPuzzle.Array[i] / 5;
                int C = dataPuzzle.Array[i] % 5;
                SetValuePuzz(R, C, 1);
            }
        }
    }
}
