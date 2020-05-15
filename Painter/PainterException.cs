using System;

namespace MatrixCreator.Painter
{
    public class PainterException : ArgumentException
    {
        public PainterException()
            : base() { }

        public PainterException(string message) 
            : base(message) { }
    }
}