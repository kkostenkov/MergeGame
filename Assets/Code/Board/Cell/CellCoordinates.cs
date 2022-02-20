namespace Merge.Board
{
    public readonly struct CellCoordinates
    {
        public readonly int X;
        public readonly int Y;

        public CellCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object other)
        {
            if (other is CellCoordinates otherCoords)
            {
                return otherCoords.X == X && otherCoords.Y == Y;
            }

            return false;
        }

        public bool Equals(CellCoordinates other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
    }
}