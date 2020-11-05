using System;
using System.Collections.Generic;
using Store.Model;
using Store.Repository.Interface.Crud;

namespace Store.Repository.Interface {

    public interface IDataInvoice : IDataCrud<Invoice> {

        Invoice GetInvoice(Guid id);

        IEnumerable<Invoice> GetAllInvoices();

    }

}
