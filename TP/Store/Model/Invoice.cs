using System;

namespace Store.Model {

    public class Invoice {

        /*------------------------ PROPERTY REGION ------------------------*/
        public Guid Id { get; } = Guid.NewGuid();
        public Warehouse Warehouse { get; set; }
        public Client Client { get; set; }
        public DateTime PurchaseDate { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public Invoice(Warehouse warehouse, Client client, DateTime purchaseDate) {
            Warehouse = warehouse;
            Client = client;
            PurchaseDate = purchaseDate;
        }

        protected bool Equals(Invoice other) {
            return Equals(Warehouse, other.Warehouse) && Equals(Client, other.Client) &&
                   PurchaseDate.Equals(other.PurchaseDate);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Invoice) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = (Warehouse != null ? Warehouse.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Client != null ? Client.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PurchaseDate.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() {
            return $"Id: {Id}, Warehouse: {Warehouse}, " +
                   $"Client: {Client}, PurchaseDate: {PurchaseDate}";
        }

    }

}
