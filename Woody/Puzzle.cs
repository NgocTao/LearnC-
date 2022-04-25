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
        public Block[,] BlockData;

        public int MinCot = 6;
        public int MaxRow = -1;

        public void SetValuePuzz(int row, int colum, int value)
        {
            BlockData[row, colum].value = value;
        }

        public void ShowPuzz()
        {
            string str = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    str += BlockData[i, j].value.ToString() + " ";
                }
                str += "\n";
            }
            Console.WriteLine(str);
        }

        public Puzzle(PuzzleData dataPuzzle)
        {
            BlockData = new Block[Rows, Colums];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    BlockData[i, j] = new Block();
                    BlockData[i, j].value = 0;
                }
            }
            
            for (int i = 0; i < dataPuzzle.Array.Length; i++)
            {
                int C = dataPuzzle.Array[i] % 5;
                if (C < MinCot)
                    MinCot = C;
                int R = dataPuzzle.Array[i] / 5;
                if (R > MaxRow)
                    MaxRow = R;
                SetValuePuzz(R, C, 1);
            }
            // SetValuePuzz(MaxRow, MinCot, 2);

        }
    }
}
