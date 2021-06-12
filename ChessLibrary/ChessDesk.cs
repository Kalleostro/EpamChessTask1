using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class ChessDesk
    {
        private List<Figure> _figures = new List<Figure>();
        private Player player1 = new Player(ChessColors.White);
        private Player player2 = new Player(ChessColors.Black);

        public void ChessGameProcess()
        {
            var position = new Position(1, 3);
            player1.GetFigure(position).Move(new Position(3,3));
        }

        // public void Intersects(Player player1, Player player2)
        // {
        //     player1.King.Coordinates == player2
        // }
    }
}