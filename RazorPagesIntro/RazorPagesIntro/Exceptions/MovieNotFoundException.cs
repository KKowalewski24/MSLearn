using System;

namespace RazorPagesIntro.Exceptions
{
    public class MovieNotFoundException : MovieException
    {
        public MovieNotFoundException()
        {
        }

        public MovieNotFoundException(string message)
            : base(message)
        {
        }

        public MovieNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}