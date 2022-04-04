using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.DataLayer.Entities;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> Index();
        Task<Book> Details(Guid? id);
        Task Create(Book book);
        Task<Book> Edit(Guid? id);
        Task<Book> Edit(Guid id, Book book);
        Task<Book> Delete(Guid? id);
        Task DeleteConfirmed(Guid id);
        Task<bool> BookExists(Guid id);
    }
}
