using System;

namespace RazorPagesIntro.Exceptions
{
    public abstract class CustomerException : Exception
    {
        protected CustomerException()
        {
        }

        protected CustomerException(string message)
            : base(message)
        {
        }

        protected CustomerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}