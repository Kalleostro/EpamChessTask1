using System;
using System.Reflection.Emit;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public abstract class Figure:ICloneable
    {
        public bool IsDead { get; protected set; }
        public Position Position { get; protected set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void Move(Position position)
        {
            Position = position;
        }
    }
}