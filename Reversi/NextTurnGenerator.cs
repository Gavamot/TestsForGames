using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using MoreLinq;

namespace Reversi
{
    public class NextTurnGenerator
    {
        public const int ImpossibleMove = -1;
        struct MapValue
        {
            public MapValue(int x, int y, int value)
            {
                Position = new Position(x, y);
                Value = value;
            }

            public Position Position { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return $"{Position} : {Value}";
            }
        }

    
        
        public string FindMaxStep(Board board)
        {
            var mapValues = GenerateBoardMapValue(board);
            var res = mapValues.MaxBy(x=>x.Value);
            return res.Position.ToString();
        }

        MapValue[] GenerateBoardMapValue(Board board)
        {
            var res = new MapValue[board.Width * board.Height];

            for (int x = 0; x < board.Height; x++)
                for (int y = 0; y < board.Width; y++)
                    res[y + x * board.Width] = new MapValue(x, y, CountValue(board, x,y));
            return res;
        }

        int CountValue(Board board, int x, int y)
        {
            if (board[x, y] != TileTypes.Empty)
                return ImpossibleMove;
            int res = 0;

            res += CountBySide(board, x, y, checker: pos => --pos.X >= 0); // Top
            res += CountBySide(board, x, y, checker: pos => ++pos.X < board.Height); // Bottom

            res += CountBySide(board, x, y, checker: pos => --pos.Y >= 0); // Left
            res += CountBySide(board, x, y, checker: pos => ++pos.Y < board.Width); // Right

            res += CountBySide(board, x, y, checker: pos => --pos.X >= 0 && --pos.Y >= 0); // Diagonal
            res += CountBySide(board, x, y, checker: pos => ++pos.X < board.Height && ++pos.Y < board.Width); // Diagonal

            res += CountBySide(board, x, y, checker: pos => --pos.X >= 0 && ++pos.Y < board.Width); // AntiDiagonal
            res += CountBySide(board, x, y, checker: pos => ++pos.X < board.Height && --pos.Y >= 0); //  AntiDiagonal

            return res;
        }

     
        int CountBySide(Board board, int x, int y, Func<Position, bool> checker)
        {
            var res = 0;
            var pos = new Position(x, y);
            while (checker(pos))
            {
                if (board[pos] == TileTypes.Enemy)
                    res++;
                if (board[pos] == TileTypes.Empty)
                    return 0;
                if (board[pos] == TileTypes.Player)
                    return res;
            }
            return 0;
        }

    }
}