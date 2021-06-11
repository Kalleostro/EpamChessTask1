namespace ChessLibrary.Figures
{
    public class Pawn:Figure
    {
        public Pawn(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Coordinates(startX, startY);
        }
    }
}