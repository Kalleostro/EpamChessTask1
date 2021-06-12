namespace ChessLibrary.Figures
{
    public class Queen:Figure
    {
        public Queen(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }
    }
}