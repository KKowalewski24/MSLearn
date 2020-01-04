using System;

namespace RazorPagesIntro.Exceptions
{
    public abstract class MovieException : Exception
    {
        protected MovieException()
        {
        }

        protected MovieException(string message)
            : base(message)
        {
        }

        protected MovieException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}