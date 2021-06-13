using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary.Figures
{
    public class Pawn:Figure
    {
        private ChessColors color;
        private bool isFirstTurn = true; 
        public Pawn(uint startX, uint startY, ChessColors color)
        {
            IsDead = false;
            var position = new Position(startX, startY);
            this.color = color;
        }

        public override List<Position> GetPosition(ChessDesk desk)
        {
            var positions = new List<Position>();
            if (isFirstTurn)
                if (color.Equals(ChessColors.White))
                {
                    positions.Add(new Position(this.Position.x, this.Position.y + 2));
                    positions.Add(new Position(this.Position.x, this.Position.y + 1));
                }
                else
                {
                    positions.Add(new Position(this.Position.x, this.Position.y - 2));
                    positions.Add(new Position(this.Position.x, this.Position.y - 1));
                }
            else if (color.Equals(ChessColors.White))
                positions.Add(new Position(this.Position.x, this.Position.y + 1));
            else if (color.Equals(ChessColors.Black))
                positions.Add(new Position(this.Position.x, this.Position.y - 1));
            else throw new Exception("Cannot finish the turn: ");
            foreach (Figure figure in color == ChessColors.White? desk.player2.FiguresLeft : desk.player1.FiguresLeft)
                if (color == ChessColors.White)
                    if ((figure.Position.x - 1 == this.Position.x && figure.Position.y - 1 == this.Position.y) || (figure.Position.x + 1 == this.Position.x && figure.Position.y - 1 == this.Position.y))
                        positions.Add(new Position(figure.Position.x, figure.Position.y));
                    else if ((figure.Position.x - 1 == this.Position.x && figure.Position.y + 1 == this.Position.y) || (figure.Position.x + 1 == this.Position.x && figure.Position.y + 1 == this.Position.y))
                        positions.Add(new Position(figure.Position.x, figure.Position.y));
            return positions;
        }

        public override void Move(Position position)
        {
            isFirstTurn = false;
            if (color == ChessColors.White)
                base.Move(position);
        }
    }
}