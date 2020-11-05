using System;

namespace Store.Model {

    public class Warehouse {

        /*------------------------ PROPERTY REGION ------------------------*/
        public Guid Id { get; } = Guid.NewGuid();
        public Product Product { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public Warehouse(Product product, int price, int quantity) {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        protected bool Equals(Warehouse other) {
            return Equals(Product, other.Product) && Price == other.Price &&
                   Quantity == other.Quantity;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Warehouse) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = (Product != null ? Product.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price;
                hashCode = (hashCode * 397) ^ Quantity;
                return hashCode;
            }
        }

        public override string ToString() {
            return $"Id: {Id}, Product: {Product}, Price: {Price}, Quantity: {Quantity}";
        }

    }

}
