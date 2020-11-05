using System;

namespace Store.Repository.Interface.Crud {

    public interface IDataCrud<T> {

        void Add(T obj);

        T Update(Guid id, T obj);

        void Delete(T obj);

    }

}
