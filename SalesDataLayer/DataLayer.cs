using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Context;
using Sales.DataLayer.Entities;

namespace Sales.DataLayer
{
    internal class DataLayer : IDataLayer
    {
        private readonly SalesContext _context;

        public DataLayer(SalesContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> Index()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }
        public async Task<Book> Details(Guid? id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);

            return book;
        }
        public async Task Create(Book book)
        {
            _context.Add(book);

            await _context.SaveChangesAsync();
        }
        public async Task<Book> Edit(Guid? id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }
        public async Task<Book> Edit(Guid id, Book book)
        {
            _context.Update(book);

            await _context.SaveChangesAsync();

            return book;
        }
        public async Task<Book> Delete(Guid? id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);

            return book;
        }
        public async Task DeleteConfirmed(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
        }
        public async Task<bool> BookExists(Guid id)
        {
            var bookExist = await _context.Books.AnyAsync(e => e.Id == id);

            return bookExist;
        }
    }
}
