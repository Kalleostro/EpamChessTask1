using System;

namespace ChessLibrary
{
    public abstract class Figure:ICloneable
    {
        public 
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}