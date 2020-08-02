using System;

namespace RazorPagesIntro.Exceptions.Movie {

    public abstract class MovieException : Exception {

        /*----------------------- PROPERTIES REGION ----------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        protected MovieException() {
        }

        protected MovieException(string message)
            : base(message) {
        }

        protected MovieException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
