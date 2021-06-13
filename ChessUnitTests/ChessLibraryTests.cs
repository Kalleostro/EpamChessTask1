using ChessLibrary;
using ChessLibrary.Figures;
using System;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using NUnit.Framework;

namespace ChessUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PawnTurnsIntoQueen()
        {
            ChessDesk desk = new ChessDesk();
            desk.MakeTurn(new Position(3,2),new Position(3,4));
            desk.MakeTurn(new Position(4,7),new Position(4,6));
            desk.MakeTurn(new Position(3,4),new Position(3,5));
            desk.MakeTurn(new Position(4,6),new Position(4,5));
            desk.MakeTurn(new Position(3,5),new Position(3,6));
            desk.MakeTurn(new Position(4,5),new Position(4,4));
            desk.MakeTurn(new Position(3,6),new Position(2,7));
            desk.MakeTurn(new Position(4,4),new Position(4,3));
            desk.MakeTurn(new Position(2,7),new Position(1,8));
            Assert.AreEqual(desk.Player1.FiguresLeft[2].GetType(),typeof(Queen));
        }

        [Test]
        public void TurnChanges()
        {
            ChessDesk desk = new ChessDesk();
            desk.MakeTurn(new Position(3,2),new Position(3,4));
            Assert.IsTrue(desk.CurrentTurnPlayer.Equals(desk.Player2));
        }

        [Test]
        public void FirstTurnPawnAvailablePositions()
        {
            ChessDesk desk = new ChessDesk();
            Assert.IsTrue(desk.Player1.FiguresLeft[0].GetPositions(desk).Count == 2);
        }
        [Test]
        public void PawnThrowsException()
        {
            ChessDesk desk = new ChessDesk();
            Assert.Throws(typeof(Exception), () => desk.MakeTurn(new Position(3,2), new Position(4,3)));
        }

        [Test]
        public void PawnWasKilled()
        {
            ChessDesk desk = new ChessDesk();
            desk.MakeTurn(new Position(3,2),new Position(3,4));
            desk.MakeTurn(new Position(4,7),new Position(4,5));
            desk.MakeTurn(new Position(3,4),new Position(4,5));
            Assert.IsTrue(desk.Player2.FiguresLeft.Count == 15);
        }
    }
}