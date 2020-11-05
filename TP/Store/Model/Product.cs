using System;

namespace Store.Model {

    public class Product {

        /*------------------------ PROPERTY REGION ------------------------*/
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public Product(string name, string description, string type) {
            Name = name;
            Description = description;
            Type = type;
        }

        protected bool Equals(Product other) {
            return Name == other.Name && Description == other.Description && Type == other.Type;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Type: {Type}";
        }

    }

}
