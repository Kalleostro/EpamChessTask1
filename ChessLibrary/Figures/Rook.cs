using System.Collections.Generic;

namespace ChessLibrary.Figures
{
    public class Rook:Figure
    {
        public Rook(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }
        public override List<Position> GetPosition(ChessDesk desk)
        {
            var positions = new List<Position>
            {
                new Position(this.Position.x + 1, this.Position.y),
                new Position(this.Position.x + 1, this.Position.y + 1),
                new Position(this.Position.x, this.Position.y + 1),
                new Position(this.Position.x - 1, this.Position.y - 1),
                new Position(this.Position.x, this.Position.y - 1),
                new Position(this.Position.x + 1, this.Position.y - 1),
                new Position(this.Position.x - 1, this.Position.y),
                new Position(this.Position.x - 1, this.Position.y + 1)
            };
            return positions;
        }

        public override void Move(Position position)
        {
            base.Move(position);
        }
    }
}