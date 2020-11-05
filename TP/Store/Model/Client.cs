using System;

namespace Store.Model {

    public class Client {

        /*------------------------ PROPERTY REGION ------------------------*/
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public Client(string firstName, string lastName, string email, string nationality) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Nationality = nationality;
        }

        protected bool Equals(Client other) {
            return FirstName == other.FirstName && LastName == other.LastName &&
                   Email == other.Email && Nationality == other.Nationality;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Client) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Nationality != null ? Nationality.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, " +
                   $"Email: {Email}, Nationality: {Nationality}";
        }

    }

}
