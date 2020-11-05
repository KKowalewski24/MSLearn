namespace Store.Exception {

    public class InvalidIdException : System.Exception {

        /*------------------------ PROPERTY REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public InvalidIdException() {
        }

        public InvalidIdException(string message)
            : base(message) {
        }

    }

}
