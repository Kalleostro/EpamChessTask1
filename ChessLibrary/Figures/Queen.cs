using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessLibrary.Figures
{
    public class Queen:Figure
    {
        public Queen(int startX, int startY)
        {
            IsDead = false;
            Position = new Position(startX, startY);
        }
        public override List<Position> GetPositions(ChessDesk desk)
        {
            var positions = new List<Position>();
            positions.AddRange(CalculateAvailablePositions(new Position(1,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,-1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(1,-1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(1,0),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(0,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(0,-1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,0),desk));
            return positions;
        }

        public override void Move(Position position, ChessDesk desk)
        {
            if (GetPositions(desk).Contains(position))
                this.Position = position;
            else throw new Exception("Invalid position!");
        }
    }
}