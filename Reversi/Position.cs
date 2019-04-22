namespace Reversi
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
       

        public override string ToString()
        {
            return $"{alphabet[Y]}{X + 1}";
        }
    }
}