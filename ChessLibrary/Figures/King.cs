namespace ChessLibrary.Figures
{
    public class King:Figure
    {
        public King(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }
    }
}