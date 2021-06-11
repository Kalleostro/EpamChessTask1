using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class Player
    {
        public string Color;
        public bool Turn;
        public List<Figure> FiguresLeft = new List<Figure>();
        public List<Figure> FiguresDead = new List<Figure>();

        public Player(string color)
        {
            InitializeFigures();
            this.Color = color;
        }

        public void ChangeFigureStatus(Figure figure)
        {
            if (figure.IsDead)
            {
                FiguresLeft.Remove(figure);
                FiguresDead.Add(figure);
            }
        }
        private void InitializeFigures()
        {
            if (Color == "white")
            {
                for (uint i = 0; i < 8; i++)
                    FiguresLeft.Add(new Pawn(i, 2));
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
                    FiguresLeft.Add(new Pawn(i, 7));
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
    }
}