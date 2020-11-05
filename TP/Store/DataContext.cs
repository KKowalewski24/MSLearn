using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Store.Model;

namespace Store {

    public class DataContext {

        /*------------------------ PROPERTY REGION ------------------------*/
        public List<Client> Clients { get; } = new List<Client>();
        public Dictionary<Guid, Product> Products { get; } = new Dictionary<Guid, Product>();

        public ObservableCollection<Invoice> Invoices { get; } =
            new ObservableCollection<Invoice>();

        public List<Warehouse> Warehouses { get; } = new List<Warehouse>();

        /*------------------------ METHODS REGION ------------------------*/

    }

}
