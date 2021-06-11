namespace ChessLibrary.Figures
{
    public class Rook:Figure
    {
        public Rook(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Coordinates(startX, startY);
        }
    }
}