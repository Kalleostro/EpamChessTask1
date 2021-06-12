namespace ChessLibrary.Figures
{
    public class Pawn:Figure
    {
        private ChessColors color;
        private bool isFirstTurn = true; 
        public Pawn(uint startX, uint startY, ChessColors color)
        {
            IsDead = false;
            var position = new Position(startX, startY);
            this.color = color;
        }

        public override void Move(Position position)
        {
            isFirstTurn = false;
            if (color == ChessColors.White)
                base.Move(position);
        }
    }
}