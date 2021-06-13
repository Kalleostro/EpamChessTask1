using System.Collections.Generic;
using ChessLibrary.Figures;
using System.Linq;

namespace ChessLibrary
{
    public class Player
    {
        private ChessColors color;
        public bool Turn;
        public List<Figure> FiguresLeft;
        public List<Figure> FiguresDead;

        public Player(ChessColors color)
        {
            InitializeFigures();
            this.color = color;
        }

        public Figure GetFigure(Position position)
        {
            return FiguresLeft.First(figure => figure.Position.Equals(position));
        }

        public void ChangeFigureStatus(Figure figure)
        {
            if (!figure.IsDead) return;
            FiguresLeft.Remove(figure);
            FiguresDead.Add(figure);
        }
        private void InitializeFigures()
        {
            if (color == ChessColors.White)
            {
                for (uint i = 0; i < 8; i++)
                    FiguresLeft.Add(new Pawn(i, 2, color));
                FiguresLeft.Add(new Bishop(3,1));
                FiguresLeft.Add(new Bishop(6,1));
                FiguresLeft.Add(new Rook(1,1));
                FiguresLeft.Add(new Rook(8,1));
                FiguresLeft.Add(new Knight(2,1));
                FiguresLeft.Add(new Knight(7,1));
                FiguresLeft.Add(new Queen(5,1));
                FiguresLeft.Add(new King(4,1));
            }
            else
            {
                for (uint i = 0; i < 8; i++)
                    FiguresLeft.Add(new Pawn(i, 7, color));
                FiguresLeft.Add(new Bishop(3,8));
                FiguresLeft.Add(new Bishop(6,8));
                FiguresLeft.Add(new Rook(1,8));
                FiguresLeft.Add(new Rook(8,8));
                FiguresLeft.Add(new Knight(2,8));
                FiguresLeft.Add(new Knight(7,8));
                FiguresLeft.Add(new Queen(5,8));
                FiguresLeft.Add(new King(4,8));
            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}