using System;
using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class ChessDesk
    {
        public Player player1;
        public Player player2;
        public Player currentTurnPlayer;
        private Logger logList;

        public ChessDesk()
        {
            player1 = new Player(ChessColors.White);
            player2 = new Player(ChessColors.Black);
            currentTurnPlayer = player1;
            logList = new Logger();
        }
        public void MakeTurn(Position figureToChoosePosition, Position toMovePosition)
        {
            try
            {
                currentTurnPlayer.GetFigure(figureToChoosePosition).Move(toMovePosition, this);
                CheckIfIntersects();
                currentTurnPlayer = Equals(currentTurnPlayer, player1) ? player2 : player1;
                logList.MakeLog("Player: " + currentTurnPlayer.ToString() + "figure: " + 
                                currentTurnPlayer.GetFigure(figureToChoosePosition).GetType().ToString() + "new position: " + 
                                toMovePosition.ToString()) ;
            }
            catch (Exception e)
            {
                logList.MakeLog(e.Message);
            }
        }
        /// <summary>
        /// kill the enemy figure if it intersects with the movable one
        /// </summary>
        private void CheckIfIntersects()
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

        public void ExchangePawn(Pawn pawn)
        {
            int pawnIndex = currentTurnPlayer.FiguresLeft.IndexOf(pawn);
            Queen newFigure = new Queen(pawn.Position.x, pawn.Position.y);
            currentTurnPlayer.FiguresLeft[pawnIndex] = newFigure;
        }
    }
}