using System;
using System.Linq;

namespace Reversi
{
    class Program
    {
        public static void Main(String[] args)
        {
            // 1. Correct Answer: "E1"
            string board1 = @"5 1 
                X O O O .";

            string result1 = Solution.PlaceToken(board1); Console.WriteLine("board 1: " + result1);

// 2. Correct Answer: "B2"
            string board2 = @"8 7
                . . . . . . . .
                . . . . . . . .
                . . O . . . . .
                . . . O X . . .
                . . . X O O . .
                . . . . . X . .
                . . . . . . X .";

            string result2 = Solution.PlaceToken(board2); Console.WriteLine("board 2: " + result2);

// 3. Correct Answer: "D3", "C4", "F5", "E6"
            string board3 = @"8 8
                . . . . . . . .
                . . . . . . . .
                . . . . . . . .
                . . . O X . . .
                . . . X O . . .
                . . . . . . . .
                . . . . . . . .
                . . . . . . . .";

            string result3 = Solution.PlaceToken(board3);
            Console.WriteLine("board 3: " + result3);

            // 4. Correct Answer: "D6
            string board4 = @"7 6
                . . . . . . .
                . . . O . O . 
                X O O X O X X
                . O X X X O X
                . X O O O . X
                . . . . . . .";



            string result4 = Solution.PlaceToken(board4); Console.WriteLine("board 4: " + result4);
        }



    }

    public class Solution
    {
        public static string PlaceToken(string board)
        {
            var b = new Board(board);
            return "A1";
        }
    }


    public enum TileTypes
    {
        Empty = '.',
        Enemy = 'O',
        Player = 'X'
    }

    public class Board
    {
        private int width;

        public int Width
        {
            get => width;
            private set
            {
                if(value <= 3 || value > 26)
                    throw new ArgumentException();
                width = value;
            }
        }

        private int height;
        public int Height
        {
            get => height;
            private set
            {
                if (value <= 0 || value > 26)
                    throw new ArgumentException();
                height = value;
            }
        }

        public Board(string str)
        {
            var settings = str.Split(Environment.NewLine);
            var wh = settings[0]
                .Split(" ")
                .Select(x=> x.Trim())
                .Select(int.Parse)
                .ToArray();

            width = wh[0];
            height = wh[1];

        }

      
    }

}
