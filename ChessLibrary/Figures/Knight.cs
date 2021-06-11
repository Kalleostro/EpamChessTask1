namespace ChessLibrary.Figures
{
    public class Knight:Figure
    {
        public Knight(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Coordinates(startX, startY);
        }
    }
}