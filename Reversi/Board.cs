namespace Reversi
{
    public class Board
    {
        public Board(TileTypes[,] board)
        {
            this.board = board;
        }

        private TileTypes[,] board;

        public TileTypes this[int x, int y]
        {
            get => board[x, y];
            set => board[x, y] = value; 
        }

        public TileTypes this[Position pos]
        {
            get => board[pos.X, pos.Y];
            set => board[pos.X, pos.Y] = value;
        }

        public int Height => board.GetLength(0);
        public int Width => board.GetLength(1);
    }
}