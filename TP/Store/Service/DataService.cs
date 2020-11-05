using System;
using System.Collections.Generic;
using System.Text;
using Store.Model;
using Store.Repository;
using Store.Service.Interface;

namespace Store.Service {

    public class DataService : IDataServiceClient, IDataServiceInvoice, IDataServiceProduct,
                               IDataServiceWarehouse {

        /*------------------------ PROPERTY REGION ------------------------*/
        private readonly DataRepository _dataRepository;

        public event EventHandler InvoiceAdded {
            add => _dataRepository.AddInvoice += value;
            remove => _dataRepository.AddInvoice += value;
        }

        public event EventHandler InvoiceDeleted {
            add => _dataRepository.DeleteInvoice += value;
            remove => _dataRepository.DeleteInvoice += value;
        }

        /*------------------------ METHODS REGION ------------------------*/
        public DataService(DataRepository dataRepository) {
            _dataRepository = dataRepository;
        }

        /*---------- CLIENT ----------*/
        public void AddClient(Client client) {
            _dataRepository.Add(client);
        }

        public void UpdateClient(Guid id, Client client) {
            _dataRepository.Update(id, client);
        }

        public void DeleteClient(Client client) {
            _dataRepository.Delete(client);
        }

        public Client GetClient(Guid id) {
            return _dataRepository.GetClient(id);
        }

        public IEnumerable<Client> GetAllClients() {
            return _dataRepository.GetAllClients();
        }

        /*---------- INVOICE ----------*/
        public void AddInvoice(Invoice invoice) {
            _dataRepository.Add(invoice);
        }

        public void UpdateInvoice(Guid id, Invoice invoice) {
            _dataRepository.Update(id, invoice);
        }

        public void DeleteInvoice(Invoice invoice) {
            _dataRepository.Delete(invoice);
        }

        public Invoice GetInvoice(Guid id) {
            return _dataRepository.GetInvoice(id);
        }

        public IEnumerable<Invoice> GetAllInvoices() {
            return _dataRepository.GetAllInvoices();
        }

        /*---------- PRODUCT ----------*/
        public void AddProduct(Product product) {
            _dataRepository.Add(product);
        }

        public void UpdateProduct(Guid id, Product product) {
            _dataRepository.Update(id, product);
        }

        public void DeleteProduct(Product product) {
            _dataRepository.Delete(product);
        }

        public Product GetProduct(Guid id) {
            return _dataRepository.GetProduct(id);
        }

        public IEnumerable<Product> GetAllProducts() {
            return _dataRepository.GetAllProducts();
        }

        /*---------- WAREHOUSE ----------*/
        public void AddWarehouse(Warehouse warehouse) {
            _dataRepository.Add(warehouse);
        }

        public void UpdateWarehouse(Guid id, Warehouse warehouse) {
            _dataRepository.Update(id, warehouse);
        }

        public void DeleteWarehouse(Warehouse warehouse) {
            _dataRepository.Delete(warehouse);
        }

        public Warehouse GetWarehouse(Guid id) {
            return _dataRepository.GetWarehouse(id);
        }

        public IEnumerable<Warehouse> GetAllWarehouses() {
            return _dataRepository.GetAllWarehouses();
        }

        /*---------- CUSTOM  ----------*/
        public IEnumerable<Invoice> GetAllClientInvoices(Client client) {
            List<Invoice> invoices = new List<Invoice>();

            foreach (var it in GetAllInvoices()) {
                if (it.Client.Id.Equals(client.Id)) {
                    invoices.Add(it);
                }
            }

            return invoices;
        }

        public IEnumerable<Invoice> GetInvoiceBetween(DateTime dateFrom, DateTime dateTo) {
            List<Invoice> invoices = new List<Invoice>();

            foreach (var it in GetAllInvoices()) {
                if (dateFrom >= it.PurchaseDate && dateTo <= it.PurchaseDate) {
                    invoices.Add(it);
                }
            }

            return invoices;
        }

        public string DisplayClients() {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var it in GetAllClients()) {
                stringBuilder.Append(it).Append("\n");
            }

            return stringBuilder.ToString();
        }

        public string DisplayInvoices() {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var it in GetAllInvoices()) {
                stringBuilder.Append(it).Append("\n");
            }

            return stringBuilder.ToString();
        }

        public string DisplayProducts() {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var it in GetAllProducts()) {
                stringBuilder.Append(it).Append("\n");
            }

            return stringBuilder.ToString();
        }

        public string DisplayWarehouses() {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var it in GetAllWarehouses()) {
                stringBuilder.Append(it).Append("\n");
            }

            return stringBuilder.ToString();
        }

    }

}
