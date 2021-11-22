using System;

namespace BusBoard
{
    public class TflApiRequestFailedException : Exception
    {
        public TflApiRequestFailedException()
        {
            
        }
        public TflApiRequestFailedException(string message) : base(message)
        {
            
        }
        public TflApiRequestFailedException(string message, Exception inner) : base(message, inner)
        {
            
        }
        
    }
}