using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ChessLibrary.Figures
{
    public class Knight:Figure
    {
        public Knight(int startX, int startY)
        {
            IsDead = false;
            this.Position = new Position(startX, startY);
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

        protected override IEnumerable<Position> CalculateAvailablePositions(Position directPosition, ChessDesk desk)
        {
            var availableList = new List<Position>();
            var temporaryPosition = this.Position;
            if (temporaryPosition.X+directPosition.X is < 9 and >= 1 && temporaryPosition.Y+directPosition.Y is < 9 and >= 1)
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
                temporaryPosition.X += directPosition.X;
                temporaryPosition.Y += directPosition.Y;
                availableList.Add(temporaryPosition);
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