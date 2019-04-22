using System;
using System.Linq;

namespace Reversi
{
    public class BoardStrArgumentException : ArgumentException
    {
        public BoardStrArgumentException() : base("wrong str format")
        {

        }
    }

    public class BoardFactory
    {
        public TileTypes GetTileType(string tile)
        {
            if(tile.Length != 1)
                throw new FormatException();
            return (TileTypes) tile[0];
        }

        private const int MaxSize = 26;
        private string[] ParseSettings(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new BoardStrArgumentException();
            var settings = token.Split(Environment.NewLine);
            if (settings.Length < 2 || settings.Length > MaxSize + 1)
                throw new BoardStrArgumentException();
            return settings;
        }

        private (int,int) ParseSize(string firstLine)
        {
            var size = firstLine
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int w = size[0];
            if (w <= 3 || w > MaxSize)
                throw new ArgumentException();
            int h = size[1];
            if (h <= 0 || h > MaxSize)
                throw new ArgumentException();

            return (w, h);
        }

        private TileTypes[,] ParseBoardField(string[] board, int w, int h)
        {
            var res = new TileTypes[h, w];
            // May be out of range exception
            for (int x = 0; x < h; x++)
            {
                var columns = board[x].Trim().Split(" ");
                for (int y = 0; y < w; y++)
                {
                    res[x, y] = GetTileType(columns[y]);
                }
            }
            return res;
        }

        public Board Create(string token)
        {
            var settings = ParseSettings(token);
            (int w, int h) = ParseSize(settings[0]);
            var boardFieldSettings = settings.Skip(1).ToArray();
            var boardField = ParseBoardField(boardFieldSettings, w, h);
            return new Board(boardField);
        }
    }
}