using System;
using System.Collections.Generic;
using Store.Model;
using Store.Repository.Interface.Crud;

namespace Store.Repository.Interface {

    public interface IDataClient : IDataCrud<Client> {

        Client GetClient(Guid id);

        IEnumerable<Client> GetAllClients();

    }

}
