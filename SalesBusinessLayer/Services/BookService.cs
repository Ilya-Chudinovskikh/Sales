using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.DataLayer.Interfaces;
using Sales.BusinessLayer.Interfaces;
using Sales.DataLayer.Entities;

namespace Sales.BusinessLayer.Services
{
    internal class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository businessLayer)
        {
            _bookRepository = businessLayer;
        }
        public Task<List<Book>> Index()
        {
            var books = _bookRepository.Index();

            return books;
        }

        public Task<Book> Details(Guid? id)
        {
            var book = _bookRepository.Details(id);

            return book;
        }

        public Task Create(Book book)
        {
            book.Id = Guid.NewGuid();

            var result = _bookRepository.Create(book);

            return result;
        }

        public Task<Book> Edit(Guid? id)
        {
            var book = _bookRepository.Edit(id);

            return book;
        }

        public Task<Book> Edit(Guid id, Book book)
        {
            var editedBook = _bookRepository.Edit(id, book);

            return editedBook;
        }

        public Task<Book> Delete(Guid? id)
        {
            var book = _bookRepository.Delete(id);

            return book;
        }

        public Task DeleteConfirmed(Guid id)
        {
            var result = _bookRepository.DeleteConfirmed(id);

            return result;
        }
        public Task<bool> BookExists(Guid id)
        {
            var bookExist = _bookRepository.BookExists(id);

            return bookExist;
        }
    }
}
