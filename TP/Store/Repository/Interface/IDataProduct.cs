using System;
using System.Collections.Generic;
using Store.Model;
using Store.Repository.Interface.Crud;

namespace Store.Repository.Interface {

    public interface IDataProduct : IDataCrud<Product> {

        Product GetProduct(Guid id);

        IEnumerable<Product> GetAllProducts();

    }

}
