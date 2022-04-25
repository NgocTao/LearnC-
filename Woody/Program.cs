using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Woody
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Init
            string text = System.IO.File.ReadAllText(@"Resource\Puzzledata.json");
            List<PuzzleData> listPuzzle = JsonConvert.DeserializeObject<List<PuzzleData>>(text);

            Board board = new Board();
            Puzzle[] puzzles = new Puzzle[3];

            // MainGame
            while (true)
            {
                if (NeedCreateNewBlocks(puzzles))
                {
                    // Tao Puzzle
                    for (int i = 0; i < puzzles.Length; i++)
                    {
                        int index = (new Random()).Next() % listPuzzle.Count;
                        puzzles[i] = new Puzzle(listPuzzle[index]);
                    }
                }
                 
                Console.Write("Nhap dong: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Nhap cot: ");
                int cot = int.Parse(Console.ReadLine());

                board.SetBlockValueBoard(row, cot, 1);
                Console.Clear();
                ShowGamePlay(board, puzzles);
            }
        }

        public static bool NeedCreateNewBlocks(Puzzle[] arrayPuzzles)
        {
            bool needCreate = true;
            for (int i = 0; i < arrayPuzzles.Length; i++)
            {
                if (arrayPuzzles[i] != null)
                {
                    needCreate = false;
                    break;
                }
            }
            return needCreate;
        }
        public static void ShowGamePlay(Board board, Puzzle[] puzzles)
        {
            Console.Clear();
            Console.WriteLine("===== BOARD =====");
            board.ShowBoard();
            for (int i = 0; i < puzzles.Length; i++)
            {
                Console.WriteLine("--- Block: {0}", i + 1);
                if (puzzles[i] == null)
                {
                    Console.WriteLine("\t\tEMTY");
                }
                else
                {
                    puzzles[i].ShowPuzz();
                }
            }
        }
    }
}


