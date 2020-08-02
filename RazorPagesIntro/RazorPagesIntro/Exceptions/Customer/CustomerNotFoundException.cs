using System;

namespace RazorPagesIntro.Exceptions.Customer {

    public class CustomerNotFoundException : CustomerException {

        /*----------------------- PROPERTIES REGION ----------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public CustomerNotFoundException() {
        }

        public CustomerNotFoundException(string message)
            : base(message) {
        }

        public CustomerNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
