﻿using Sales.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataLayer.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> Index();
        Task<Book> Details(Guid? id);
        Task Create(Book book);
        Task<Book> Edit(Guid? id);
        Task<Book> UpdateBook(Book book);
        Task<Book> Delete(Guid? id);
        Task DeleteConfirmed(Guid id);
        Task<bool> BookExists(Guid id);
    }
}

