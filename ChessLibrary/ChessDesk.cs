using System;
using System.Collections.Generic;
using ChessLibrary.Figures;

namespace ChessLibrary
{
    public class ChessDesk
    {
        public Player Player1;
        public Player Player2;
        public Player CurrentTurnPlayer;
        private Logger logList;

        public ChessDesk()
        {
            Player1 = new Player(ChessColors.White);
            Player2 = new Player(ChessColors.Black);
            CurrentTurnPlayer = Player1;
            logList = new Logger();
        }
        public void MakeTurn(Position figureToChoosePosition, Position toMovePosition)
        {
            try
            {
                CurrentTurnPlayer.GetFigure(figureToChoosePosition).Move(toMovePosition, this);
                CheckIfIntersects();
                CurrentTurnPlayer = Equals(CurrentTurnPlayer, Player1) ? Player2 : Player1;
                logList.MakeLog("Player: " + CurrentTurnPlayer + "figure: " + 
                                CurrentTurnPlayer.GetFigure(figureToChoosePosition).GetType() + "new position: " + 
                                toMovePosition) ;
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
            foreach (var player1Figure in Player1.FiguresLeft)
            {
                foreach (var player2Figure in Player2.FiguresLeft)
                {
                    if (player1Figure.Position.Equals(player2Figure.Position))
                    {
                        if (Equals(CurrentTurnPlayer, Player1))
                        {
                            player2Figure.IsDead = true;
                            Player2.ChangeFigureStatus(player2Figure);
                        }
                        else
                        {
                            player1Figure.IsDead = true;
                            Player1.ChangeFigureStatus(player1Figure);
                        }
                    }
                }
            }
        }
    }
}