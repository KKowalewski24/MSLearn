using System;
using System.Collections.Generic;
using Store.Model;

namespace Store.Service.Interface {

    public interface IDataServiceInvoice {

        void AddInvoice(Invoice invoice);

        void UpdateInvoice(Guid id, Invoice invoice);

        void DeleteInvoice(Invoice invoice);

        Invoice GetInvoice(Guid id);

        IEnumerable<Invoice> GetAllInvoices();

    }

}
