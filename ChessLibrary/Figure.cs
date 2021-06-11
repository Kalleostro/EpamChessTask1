using System;

namespace ChessLibrary
{
    public abstract class Figure:ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}