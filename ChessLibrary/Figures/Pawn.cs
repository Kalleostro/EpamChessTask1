using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary.Figures
{
    public class Pawn:Figure
    {
        private ChessColors color;
        private bool isFirstTurn = true;
        public Pawn(int startX, int startY, ChessColors color)
        {
            IsDead = false;
            this.Position = new Position(startX, startY);
            this.color = color;
        }

        public override List<Position> GetPositions(ChessDesk desk)
        {
            var positions = new List<Position>();
            //for the first turn
            if (isFirstTurn)
            {
                if (color.Equals(ChessColors.White))
                {
                    positions.Add(new Position(this.Position.X, this.Position.Y + 2));
                    positions.Add(new Position(this.Position.X, this.Position.Y + 1));
                }
                else
                {
                    positions.Add(new Position(this.Position.X, this.Position.Y - 2));
                    positions.Add(new Position(this.Position.X, this.Position.Y - 1));
                }
                isFirstTurn = false;
            } 
            //simple turn
            else switch (color)
            {
                case ChessColors.White:
                    positions.Add(new Position(this.Position.X, this.Position.Y + 1));
                    break;
                case ChessColors.Black:
                    positions.Add(new Position(this.Position.X, this.Position.Y - 1));
                    break;
                default:
                    throw new Exception("Cannot finish the turn: ");
            }
            //if diagonally exists an enemy figure
            foreach (Figure figure in color == ChessColors.White? desk.Player2.FiguresLeft : desk.Player1.FiguresLeft)
                if (color == ChessColors.White)
                {
                    if ((figure.Position.X - 1 == this.Position.X && figure.Position.Y - 1 == this.Position.Y)
                        || (figure.Position.X + 1 == this.Position.X && figure.Position.Y - 1 == this.Position.Y))
                    {
                        positions.Add(new Position(figure.Position.X, figure.Position.Y));
                    }
                    else if ((figure.Position.X - 1 == this.Position.X && figure.Position.Y + 1 == this.Position.Y)
                             || (figure.Position.X + 1 == this.Position.X && figure.Position.Y + 1 == this.Position.Y))
                    {
                        positions.Add(new Position(figure.Position.X, figure.Position.Y));
                    }
                }

            return positions;
        }
        
        public override void Move(Position position, ChessDesk desk)
        {
            if (GetPositions(desk).Contains(position))
                this.Position = position;
            else throw new Exception("Invalid position!");
            //Change Pawn to Queen if the field up/down border is reached
            if (this.Position.Y is 8 or 1)
            {
                var pawnIndex = desk.CurrentTurnPlayer.FiguresLeft.IndexOf(this);
                var newFigure = new Queen(Position.X, Position.Y);
                desk.CurrentTurnPlayer.FiguresLeft[pawnIndex] = newFigure;
            }
        }

        protected bool Equals(Pawn other)
        {
            return base.Equals(other) && color == other.color && isFirstTurn == other.isFirstTurn;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pawn) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), (int) color, isFirstTurn);
        }
    }
}