using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLibrary.Figures
{
    public class Knight:Figure
    {
        public Knight(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }
        public override List<Position> GetPositions(ChessDesk desk)
        {
            var positions = new List<Position>();
            positions.AddRange(CalculateAvailablePositions(new Position(2,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(2,-1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-2,1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-2,-1),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(1,2),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(1,-2),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,2),desk));
            positions.AddRange(CalculateAvailablePositions(new Position(-1,-2),desk));
            return positions;
        }

        public override List<Position> CalculateAvailablePositions(Vector2 position, ChessDesk desk)
        {
            throw new System.NotImplementedException();
        }

        public override void Move(Position position, ChessDesk desk)
        {
            if (GetPositions(desk).Contains(position))
                this.Position = position;
            else throw new Exception("Invalid position!");
        }
    }
}