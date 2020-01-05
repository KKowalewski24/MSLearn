using System.Collections.Generic;
using BookWebApiMongoDB.Models;
using BookWebApiMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using static BookWebApiMongoDB.Constants.Constants;

namespace BookWebApiMongoDB.Controllers
{
    [Route(PATH_API_CONTROLLER)]
    [ApiController]
    public class BookController : ControllerBase
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly BookService _bookService;

        /*------------------------ METHODS REGION ------------------------*/
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _bookService.GetAll();
        }

        [HttpGet(ID_LENGTH_24, Name = GET_BOOK)]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _bookService.Create(book);
            return CreatedAtRoute(GET_BOOK, new {id = book.Id.ToString()}, book);
        }

        [HttpPut(ID_LENGTH_24)]
        public IActionResult Update(string id, Book book)
        {
            var bookToUpdate = _bookService.GetById(id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            _bookService.Update(id, book);

            return NoContent();
        }

        [HttpDelete(ID_LENGTH_24)]
        public IActionResult Delete(string id)
        {
            var bookToDelete = _bookService.GetById(id);

            if (bookToDelete == null)
            {
                return NotFound();
            }

            _bookService.DeleteById(bookToDelete.Id);

            return NoContent();
        }
    }
}