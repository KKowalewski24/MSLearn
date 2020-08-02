using System.Collections.Generic;
using BookWebApiMongoDB.Models;

namespace BookWebApiMongoDB.Services {

    public interface IBookService {

        List<Book> GetAll();

        Book GetById(string id);

        Book Create(Book book);

        void Update(string id, Book book);

        void Delete(Book book);

        void DeleteById(string id);

    }

}
