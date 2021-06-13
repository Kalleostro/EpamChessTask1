namespace ChessLibrary.Figures
{
    public struct Position
        {
            public uint x { get; set; } 
            public uint y { get; set; } 

            public Position(uint x, uint y)
            {
                this.x = x;
                this.y = y;
            }
        }
}