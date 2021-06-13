using System.Collections.Generic;

namespace ChessLibrary.Figures
{
    public class Knight:Figure
    {
        public Knight(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }
        public override List<Position> GetPosition(ChessDesk desk)
        {
            
            List<Position> positions = new List<Position>();
            throw new System.NotImplementedException();
        }

        public override List<Position> GetAvailablePositions(Position position, ChessDesk desk)
        {
            throw new System.NotImplementedException();
        }

        public override void Move(Position position)
        {
            base.Move(position);
        }
    }
}