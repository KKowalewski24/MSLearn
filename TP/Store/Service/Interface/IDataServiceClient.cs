using System;
using System.Collections.Generic;
using Store.Model;

namespace Store.Service.Interface {

    public interface IDataServiceClient {

        void AddClient(Client client);

        void UpdateClient(Guid id, Client client);

        void DeleteClient(Client client);

        Client GetClient(Guid id);

        IEnumerable<Client> GetAllClients();

    }

}
