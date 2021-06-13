using System;
using System.Collections.Generic;

namespace ChessLibrary.Figures
{
    public class King:Figure
    {
        public King(int startX, int startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
            AvailableDirection = new Position();
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

        public override List<Position> CalculateAvailablePositions(Position directPosition, ChessDesk desk)
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
    }
}