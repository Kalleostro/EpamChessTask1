using System;
using System.Collections.Generic;
using ChessLibrary.Figures;
using System.Linq;

namespace ChessLibrary
{
    public class Player
    {
        private ChessColors color;
        public List<Figure> FiguresLeft { get; private set; }
        public List<Figure> FiguresDead { get; private set; }

        public Player(ChessColors color)
        {
            FiguresLeft = new List<Figure>();
            FiguresDead = new List<Figure>();
            InitializeFigures();
            this.color = color;
        }

        public Figure GetFigure(Position position)
        {
            return FiguresLeft.First(figure => figure.Position.Equals(position));
        }
        /// <summary>
        /// changing figure status in case of death
        /// </summary>
        /// <param name="figure">concrete dead figure</param>
        public void ChangeFigureStatus(Figure figure)
        {
            if (!figure.IsDead) return;
            FiguresLeft.Remove(figure);
            FiguresDead.Add(figure);
        }
        /// <summary>
        /// initialize desk or players figures
        /// </summary>
        private void InitializeFigures()
        {
            if (color == ChessColors.White)
            {
                for (int i = 0; i < 8; i++)
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
                for (int i = 0; i < 8; i++)
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

        protected bool Equals(Player other)
        {
            return color == other.color && Equals(FiguresLeft, other.FiguresLeft) && Equals(FiguresDead, other.FiguresDead);
        }

        public override string ToString()
        {
            return $"{nameof(color)}: {color}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) color, FiguresLeft, FiguresDead);
        }
    }
}