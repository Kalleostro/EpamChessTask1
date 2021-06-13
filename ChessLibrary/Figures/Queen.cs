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

        protected override IEnumerable<Position> CalculateAvailablePositions(Position directPosition, ChessDesk desk)
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
        
        public override void Move(Position position, ChessDesk desk)
        {
            if (GetPositions(desk).Contains(position))
                this.Position = position;
            else throw new Exception("Invalid position!");
        }
    }
}