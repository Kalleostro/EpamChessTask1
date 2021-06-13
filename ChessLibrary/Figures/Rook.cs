using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessLibrary.Figures
{
    public class Rook:Figure
    {
        public Rook(int startX, int startY)
        {
            Position = new Position(startX, startY);
            IsDead = false;
        }
        public override List<Position> GetPositions(ChessDesk desk)
        {
            var positions = new List<Position>();
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
            while (temporaryPosition.X is < 9 and >= 1 && temporaryPosition.Y is < 9 and >= 1)
            {
                if (desk.Player1.FiguresLeft.Any(figure => Equals(figure.Position, 
                    new Position(temporaryPosition.X += directPosition.X,temporaryPosition.Y += directPosition.Y))))
                {
                    return availableList;
                }
                if (desk.Player2.FiguresLeft.Any(figure => Equals(figure.Position, 
                    new Position(temporaryPosition.X += directPosition.X,temporaryPosition.Y += directPosition.Y))))
                {
                    return availableList;
                }
                else
                {
                    temporaryPosition.X += directPosition.X;
                    temporaryPosition.Y += directPosition.Y;
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