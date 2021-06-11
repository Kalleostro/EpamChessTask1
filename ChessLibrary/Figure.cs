using System;
using System.Reflection.Emit;

namespace ChessLibrary
{
    public abstract class Figure:ICloneable
    {
        public bool IsDead;

        public struct Coordinates
        {
            private uint x;
            private uint y;

            public Coordinates(uint x, uint y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}