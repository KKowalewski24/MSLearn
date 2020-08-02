using System;

namespace RazorPagesIntro.Exceptions.Movie {

    public class MovieNotFoundException : MovieException {

        /*----------------------- PROPERTIES REGION ----------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public MovieNotFoundException() {
        }

        public MovieNotFoundException(string message)
            : base(message) {
        }

        public MovieNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
