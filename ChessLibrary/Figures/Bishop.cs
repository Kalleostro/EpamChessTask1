using System;
using System.Collections.Generic;

namespace ChessLibrary.Figures
{
    public class Bishop:Figure
    {
        public Bishop(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (obj == this)
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return this == obj;
        }
        public override List<Position> GetPositions(ChessDesk desk)
        {
            var positions = new List<Position>();
            positions.AddRange(CalculateAvailablePositions(new Position(1,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,-1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(1,-1),desk));
            return positions;
        }

        public override List<Position> GetAvailablePositions(ChessDesk desk)
        {
            var availableList = new List<Position>();
            var temporaryPosition = this.Position;
            while (temporaryPosition.x is < 8 and >= 1 && temporaryPosition.y is < 8 and >= 1)
            {
                temporaryPosition
            }
        }

        public override void Move(Position position, ChessDesk desk)
        {
            if (GetPositions(desk).Contains(position))
                this.Position = position;
            else throw new Exception("Invalid position!");
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}