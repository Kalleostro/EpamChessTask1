namespace ChessLibrary.Figures
{
    public class Bishop:Figure
    {
        public Bishop(uint startX, uint startY)
        {
            IsDead = false;
            var coordinates = new Position(startX, startY);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (obj == this)
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return this == obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}