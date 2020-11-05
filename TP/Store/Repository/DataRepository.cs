using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Store.Exception;
using Store.Fill;
using Store.Model;
using Store.Repository.Interface;

namespace Store.Repository {

    public class DataRepository : IDataClient, IDataInvoice, IDataProduct, IDataWarehouse {

        /*------------------------ PROPERTY REGION ------------------------*/
        private DataContext _dataContext = new DataContext();
        private readonly IDataFiller _dataFiller;

        public event EventHandler AddInvoice;
        public event EventHandler DeleteInvoice;

        /*------------------------ METHODS REGION ------------------------*/
        public DataRepository(IDataFiller dataFiller) {
            _dataFiller = dataFiller;
            _dataFiller.Fill(_dataContext);
            _dataContext.Invoices.CollectionChanged += InvoicesCollectionChanged;
        }

        private void InvoicesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                AddInvoice?.Invoke(this, new EventArgs());
            } else if (e.Action == NotifyCollectionChangedAction.Remove) {
                DeleteInvoice?.Invoke(this, new EventArgs());
            }
        }

        /*---------- CLIENT ----------*/
        public void Add(Client obj) {
            _dataContext.Clients.Add(obj);
        }

        public Client GetClient(Guid id) {
            return _dataContext.Clients.Find(it => it.Id.Equals(id));
        }

        public IEnumerable<Client> GetAllClients() {
            return _dataContext.Clients;
        }

        /// <summary>
        /// Usage _dataRepository.Update(certainClient.Id, new Client(...))
        /// </summary>
        /// <param name="id">id of object that will be updated</param>
        /// <param name="obj">new Object that is passed to get values from</param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public Client Update(Guid id, Client obj) {
            if (!obj.Id.Equals(id)) {
                throw new InvalidIdException("Client Id must be equal to passed Id");
            }

            Client client = GetClient(id);
            client = obj;

            return client;
        }

        public void Delete(Client obj) {
            _dataContext.Clients.Remove(obj);
        }

        /*---------- INVOICE ----------*/
        public void Add(Invoice obj) {
            _dataContext.Invoices.Add(obj);
        }

        public Invoice GetInvoice(Guid id) {
            return _dataContext.Invoices.First(it => it.Id.Equals(id));
        }

        public IEnumerable<Invoice> GetAllInvoices() {
            return _dataContext.Invoices;
        }

        /// <summary>
        /// Usage _dataRepository.Update(certainProduct.Id, new Product(...))
        /// </summary>
        /// <param name="id">id of object that will be updated</param>
        /// <param name="obj">new Object that is passed to get values from</param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public Invoice Update(Guid id, Invoice obj) {
            if (!obj.Id.Equals(id)) {
                throw new InvalidIdException("Invoice Id must be equal to passed Id");
            }

            Invoice invoice = GetInvoice(id);
            invoice = obj;

            return invoice;
        }

        public void Delete(Invoice obj) {
            _dataContext.Invoices.Remove(obj);
        }

        /*---------- PRODUCT ----------*/
        public void Add(Product obj) {
            _dataContext.Products.Add(obj.Id, obj);
        }

        public Product GetProduct(Guid id) {
            try {
                return _dataContext.Products[id];
            } catch {
                return null;
            }
        }

        public IEnumerable<Product> GetAllProducts() {
            return _dataContext.Products.Values;
        }

        /// <summary>
        /// Usage _dataRepository.Update(certainProduct.Id, new Product(...))
        /// </summary>
        /// <param name="id">id of object that will be updated</param>
        /// <param name="obj">new Object that is passed to get values from</param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public Product Update(Guid id, Product obj) {
            if (!obj.Id.Equals(id)) {
                throw new InvalidIdException("Product Id must be equal to passed Id");
            }

            Product product = GetProduct(id);
            product = obj;

            return product;
        }

        public void Delete(Product obj) {
            _dataContext.Products.Remove(obj.Id);
        }

        /*---------- WAREHOUSE ----------*/
        public void Add(Warehouse obj) {
            _dataContext.Warehouses.Add(obj);
        }

        public Warehouse GetWarehouse(Guid id) {
            return _dataContext.Warehouses.Find(it => it.Id.Equals(id));
        }

        public IEnumerable<Warehouse> GetAllWarehouses() {
            return _dataContext.Warehouses;
        }

        /// <summary>
        /// Usage _dataRepository.Update(certainWarehouse.Id, new Warehouse(...))
        /// </summary>
        /// <param name="id">id of object that will be updated</param>
        /// <param name="obj">new Object that is passed to get values from</param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public Warehouse Update(Guid id, Warehouse obj) {
            if (!obj.Id.Equals(id)) {
                throw new InvalidIdException("Warehouse Id must be equal to passed Id");
            }

            Warehouse warehouse = GetWarehouse(id);
            warehouse = obj;

            return warehouse;
        }

        public void Delete(Warehouse obj) {
            _dataContext.Warehouses.Remove(obj);
        }

    }

}
