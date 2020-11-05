using System;
using Store.Model;

namespace Store.Fill {

    public class FillConstant : IDataFiller {

        /*------------------------ PROPERTY REGION ------------------------*/
        public static readonly string[] CLIENT_ARRAY = {
            "Kamil",
            "Kowalewski",
            "KamilKowalewski@gmail.com",
            "Polish"
        };

        public static readonly string[] PRODUCT_ARRAY = {
            "keyboard",
            "Logitech Keyboard",
            "Electronical Device"
        };

        public static readonly int[] WAREHOUSE_ARRAY = {
            15, 20
        };

        public static readonly DateTime STATIC_TIME = new DateTime(2019, 11, 05);

        /*------------------------ METHODS REGION ------------------------*/
        private Client PrepareClient(DataContext dataContext, string firstName,
                                     string lastName, string email, string nationality) {
            Client client = new Client(firstName, lastName, email, nationality);
            dataContext.Clients.Add(client);

            return client;
        }

        private Product PrepareProduct(DataContext dataContext, string name,
                                       string description, string type) {
            Product product = new Product(name, description, type);
            dataContext.Products.Add(product.Id, product);

            return product;
        }

        private Warehouse PrepareWarehouse(DataContext dataContext, Product product,
                                           int price, int quantity) {
            Warehouse warehouse = new Warehouse(product, price, quantity);
            dataContext.Warehouses.Add(warehouse);

            return warehouse;
        }

        private Invoice PrepareInvoice(DataContext dataContext, Warehouse warehouse,
                                       Client client, DateTime dateTime) {
            Invoice invoice = new Invoice(warehouse, client, dateTime);
            dataContext.Invoices.Add(invoice);

            return invoice;
        }

        public void Fill(DataContext dataContext) {
            Client client = PrepareClient(dataContext, CLIENT_ARRAY[0],
                CLIENT_ARRAY[1], CLIENT_ARRAY[2], CLIENT_ARRAY[3]);

            Product product = PrepareProduct(dataContext, PRODUCT_ARRAY[0],
                PRODUCT_ARRAY[1], PRODUCT_ARRAY[2]);

            Warehouse warehouse = PrepareWarehouse(dataContext, product, WAREHOUSE_ARRAY[0],
                WAREHOUSE_ARRAY[1]);

            Invoice invoice = PrepareInvoice(dataContext, warehouse, client, STATIC_TIME);
        }

    }

}
