using System;

namespace WordpressIntegration.Web.Core.Exceptions
{
    public class WordpressException : Exception
    {
        public WordpressException()
        {
        }

        public WordpressException(string message) : base(message)
        {
        }

        public WordpressException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
