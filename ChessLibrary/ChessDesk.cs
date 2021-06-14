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
                var figureToMove = CurrentTurnPlayer.GetFigure(figureToChoosePosition);
                figureToMove.Move(toMovePosition, this);
                CheckIfIntersects(toMovePosition);
                logList.MakeLog("Player: " + CurrentTurnPlayer.ToString() + " figure: " + 
                                figureToMove.GetType().ToString() + " new position: " + 
                            toMovePosition.ToString());
                CurrentTurnPlayer = Equals(CurrentTurnPlayer, Player1) ? Player2 : Player1;
        }
        /// <summary>
        /// kill the enemy figure if it intersects with the movable one
        /// </summary>
        private void CheckIfIntersects(Position toMovePosition)
        {
            var enemyPlayer = Equals(CurrentTurnPlayer, Player1) ? Player2 : Player1;
            
            foreach (Figure figure in enemyPlayer.FiguresLeft)
                if (figure.Position.Equals(toMovePosition))
                {
                    figure.IsDead = true;
                    enemyPlayer.FiguresLeft.Remove(figure);
                    return;
                }
        }

        // private void CheckIfIntersects()
        // {
        //     foreach (var player1Figure in Player1.FiguresLeft)
        //     {
        //         foreach (var player2Figure in Player2.FiguresLeft)
        //         {
        //             if (player1Figure.Position.Equals(player2Figure.Position))
        //             {
        //                 if (Equals(CurrentTurnPlayer, Player1))
        //                 {
        //                     player2Figure.IsDead = true;
        //                     Player2.ChangeFigureStatus(player2Figure);
        //                 }
        //                 else
        //                 {
        //                     player1Figure.IsDead = true;
        //                     Player1.ChangeFigureStatus(player1Figure);
        //                 }
        //                 return;
        //             }
        //         }
        //     }
        // }
    }
}