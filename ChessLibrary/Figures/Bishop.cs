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
        public override List<Position> GetPosition(ChessDesk desk)
        {
            var positions = new List<Position>();
            positions.AddRange(GetAvailablePositions(desk));
            // {
            //     new Position(this.Position.x + 1, this.Position.y),
            //     new Position(this.Position.x + 1, this.Position.y + 1),
            //     new Position(this.Position.x, this.Position.y + 1),
            //     new Position(this.Position.x - 1, this.Position.y - 1),
            //     new Position(this.Position.x, this.Position.y - 1),
            //     new Position(this.Position.x + 1, this.Position.y - 1),
            //     new Position(this.Position.x - 1, this.Position.y),
            //     new Position(this.Position.x - 1, this.Position.y + 1)
            // };
            
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

        public override void Move(Position position)
        {
            base.Move(position);
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