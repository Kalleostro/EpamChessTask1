using System;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Linq;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public abstract class Figure:ICloneable
    {
        public bool IsDead { get; set; }
        public Position Position { get; protected set; }
        public Position AvailableDirection { get; protected set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// setting directions and getting list of the available positions
        /// </summary>
        /// <param name="desk">playing desk</param>
        /// <returns>list of positions</returns>
        public abstract List<Position> GetPositions(ChessDesk desk);

        /// <summary>
        /// calculating available positions if made by vector 
        /// </summary>
        /// <param name="directPosition">available figure direction</param>
        /// <param name="desk">playing desk</param>
        /// <returns>positions</returns>
        protected virtual IEnumerable<Position> CalculateAvailablePositions(Position directPosition, ChessDesk desk)
        {
            var availableList = new List<Position>();
            var temporaryPosition = this.Position;
            while (temporaryPosition.x is < 9 and >= 1 && temporaryPosition.y is < 9 and >= 1)
            {
                if (desk.player1.FiguresLeft.Any(figure => Equals(figure.Position, 
                    new Position(temporaryPosition.x += directPosition.x,temporaryPosition.y += directPosition.y))))
                {
                    return availableList;
                }
                if (desk.player2.FiguresLeft.Any(figure => Equals(figure.Position, 
                    new Position(temporaryPosition.x += directPosition.x,temporaryPosition.y += directPosition.y))))
                {
                    return availableList;
                }
                else
                {
                    temporaryPosition.x += directPosition.x;
                    temporaryPosition.y += directPosition.y;
                    availableList.Add(temporaryPosition);
                }
            }
            return availableList;
        }
        /// <summary>
        /// move figure to the existing available position
        /// </summary>
        /// <param name="position">to move position</param>
        /// <param name="desk">playing desk</param>
        public abstract void Move(Position position, ChessDesk desk);
        
        protected bool Equals(Figure other)
        {
            return IsDead == other.IsDead && Position.Equals(other.Position);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Figure) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IsDead, Position);
        }
    }
}