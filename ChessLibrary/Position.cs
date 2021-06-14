using System;

namespace ChessLibrary.Figures
{
    public struct Position
        {
            public int X { get; set; }
            public int Y { get; set; } 

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(Position other)
            {
                return X == other.X && Y == other.Y;
            }

            public override bool Equals(object obj)
            {
                return obj is Position other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }

            public override string ToString()
            {
                return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
            }
        }
}