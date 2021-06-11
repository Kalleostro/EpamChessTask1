using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class Player
    {
        public string Color;
        public bool Turn;
        public List<Figure> FiguresLeft = new List<Figure>();
        public List<Figure> FiguresDeath;

        public Player(string color, bool turn)
        {
            InitializeFigures();
            this.Color = color;
            this.Turn = turn;
        }

        private void InitializeFigures()
        {
            FiguresLeft.Add(new Bishop());
            FiguresLeft.Add(new King());
            FiguresLeft.Add(new Knight());
            FiguresLeft.Add(new Pawn());
            FiguresLeft.Add(new Queen());
            FiguresLeft.Add(new Rook());
        }
    }
}