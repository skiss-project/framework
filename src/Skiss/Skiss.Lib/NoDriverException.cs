using System;

namespace Skiss.Lib
{
    public class NoDriverException : Exception
    {
        public NoDriverException()
        {
        }

        public NoDriverException(string message) 
            : base(message)
        {
        }

        public NoDriverException(string message, Exception inner) 
            : base(message, inner)
        {
        }
    } 
}
