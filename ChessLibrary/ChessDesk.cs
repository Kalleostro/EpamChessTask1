using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class ChessDesk
    {
        private List<Figure> _figures = new List<Figure>();
        public Player player1 = new Player(ChessColors.White);
        public Player player2 = new Player(ChessColors.Black);

        public void ChessGameProcess()
        {
            player1.GetFigure(new Position(1,3)).Move(new Position(3,3));
        }

        // public void Intersects(Player player1, Player player2)
        // {
        //     player1.King.Coordinates == player2
        // }
    }
}