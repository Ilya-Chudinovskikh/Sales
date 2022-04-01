using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.DataLayer;
using Sales.DataLayer.Entities;

namespace Sales.BusinessLayer
{
    internal class BusinessLayer : IBusinessLayer
    {
        private readonly IDataLayer _dataLayer;
        public BusinessLayer(IDataLayer businessLayer)
        {
            _dataLayer = businessLayer;
        }
        public Task<List<Book>> Index()
        {
            var books = _dataLayer.Index();

            return books;
        }

        public Task<Book> Details(Guid? id)
        {
            var book = _dataLayer.Details(id);

            return book;
        }

        public Task Create(Book book)
        {
            book.Id = Guid.NewGuid();

            var result = _dataLayer.Create(book);

            return result;
        }

        public Task<Book> Edit(Guid? id)
        {
            var book = _dataLayer.Edit(id);

            return book;
        }

        public Task<Book> Edit(Guid id, Book book)
        {
            var editedBook =_dataLayer.Edit(id, book);

            return editedBook;
        }

        public Task<Book> Delete(Guid? id)
        {
            var book = _dataLayer.Delete(id);

            return book;
        }

        public Task DeleteConfirmed(Guid id)
        {
            var result = _dataLayer.DeleteConfirmed(id);

            return result;
        }
        public Task<bool> BookExists(Guid id)
        {
            var bookExist = _dataLayer.BookExists(id);

            return bookExist;
        }
    }
}
