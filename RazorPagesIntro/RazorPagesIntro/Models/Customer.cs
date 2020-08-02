using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIntro.Models {

    public class Customer {

        /*----------------------- PROPERTIES REGION ----------------------*/
        public int Id { get; set; }

        [Required, StringLength(10)] public string Name { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public Customer() {
        }

        public Customer(int id, string name) {
            Id = id;
            Name = name;
        }

        protected bool Equals(Customer other) {
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, Name);
        }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }

    }

}
