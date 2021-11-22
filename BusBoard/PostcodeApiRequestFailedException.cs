using System;

namespace BusBoard
{
    public class PostcodeApiRequestFailedException : Exception
    {
        public PostcodeApiRequestFailedException()
        {
            
        }
        public PostcodeApiRequestFailedException(string message) : base(message)
        {
            
        }
        public PostcodeApiRequestFailedException(string message, Exception inner) : base(message, inner)
        {
            
        }
        
    }
}