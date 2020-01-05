using System.Collections.Generic;
using BookWebApiMongoDB.Models;
using BookWebApiMongoDB.Settings;
using MongoDB.Driver;

namespace BookWebApiMongoDB.Services
{
    public class BookService : IBookService
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly IMongoCollection<Book> _books;

        /*------------------------ METHODS REGION ------------------------*/
        public BookService(IBookstoreDatabaseSettings settings)
        {
            _books = new MongoClient(settings.ConnectionString)
                .GetDatabase(settings.DatabaseName)
                .GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> GetAll()
        {
            return _books.Find((it) => true).ToList();
        }

        public Book GetById(string id)
        {
            return _books.Find((it) => it.Id == id).FirstOrDefault();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book book)
        {
            _books.ReplaceOne((it) => it.Id == id, book);
        }

        public void Delete(Book book)
        {
            _books.DeleteOne((it) => it.Id == book.Id);
        }

        public void DeleteById(string id)
        {
            _books.DeleteOne((it) => it.Id == id);
        }
    }
}