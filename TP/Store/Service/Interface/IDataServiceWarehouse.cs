using System;
using System.Collections.Generic;
using Store.Model;

namespace Store.Service.Interface {

    public interface IDataServiceWarehouse {

        void AddWarehouse(Warehouse warehouse);

        void UpdateWarehouse(Guid id, Warehouse warehouse);

        void DeleteWarehouse(Warehouse warehouse);

        Warehouse GetWarehouse(Guid id);

        IEnumerable<Warehouse> GetAllWarehouses();

    }

}
