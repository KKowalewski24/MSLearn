using System;
using System.Collections.Generic;
using Store.Model;
using Store.Repository.Interface.Crud;

namespace Store.Repository.Interface {

    public interface IDataWarehouse : IDataCrud<Warehouse> {

        Warehouse GetWarehouse(Guid id);

        IEnumerable<Warehouse> GetAllWarehouses();

    }

}
