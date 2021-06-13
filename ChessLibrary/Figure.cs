using System;
using System.Reflection.Emit;
using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public abstract class Figure:ICloneable
    {
        public bool IsDead { get; set; }
        public Position Position { get; protected set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public abstract List<Position> GetPosition(ChessDesk desk);
        public abstract List<Position> GetAvailablePositions(Position position, ChessDesk desk);
        public virtual void Move(Position position)
        {
            Position = position;
        }
    }
}