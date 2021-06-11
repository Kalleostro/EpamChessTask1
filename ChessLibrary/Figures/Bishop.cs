namespace ChessLibrary.Figures
{
    public class Bishop:Figure
    {
        public Bishop(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Coordinates(startX, startY);
        }
    }
}