using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class ChessDesk
    {
        public Player player1;
        public Player player2;
        private Player currentTurnPlayer;

        public ChessDesk()
        {
            player1 = new Player(ChessColors.White);
            player2 = new Player(ChessColors.Black);
            currentTurnPlayer = player1;
        }
        public void ChessGameProcess(Position figureToChoosePosition, Position toMovePosition)
        {
            currentTurnPlayer.GetFigure(figureToChoosePosition).Move(toMovePosition);
            BeatFigure();
            currentTurnPlayer = Equals(currentTurnPlayer, player1) ? player2 : player1;
        }

        private void BeatFigure()
        {
            foreach (var player1Figure in player1.FiguresLeft)
            {
                foreach (var player2Figure in player2.FiguresLeft)
                {
                    if (player1Figure.Position.Equals(player2Figure.Position))
                    {
                        if (Equals(currentTurnPlayer, player1))
                        {
                            player2Figure.IsDead = true;
                            player2.ChangeFigureStatus(player2Figure);
                        }
                        else
                        {
                            player1Figure.IsDead = true;
                            player1.ChangeFigureStatus(player1Figure);
                        }
                    }
                }
            }
        }
        // public void Intersects(Player player1, Player player2)
        // {
        //     player1.King.Coordinates == player2
        // }
    }
}