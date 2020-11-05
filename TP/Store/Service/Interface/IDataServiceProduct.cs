using System;
using System.Collections.Generic;
using Store.Model;

namespace Store.Service.Interface {

    public interface IDataServiceProduct {

        void AddProduct(Product product);

        void UpdateProduct(Guid id, Product product);

        void DeleteProduct(Product product);

        Product GetProduct(Guid id);

        IEnumerable<Product> GetAllProducts();

    }

}
