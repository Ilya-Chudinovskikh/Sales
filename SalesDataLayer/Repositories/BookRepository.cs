using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Entities;
using Sales.DataLayer.Interfaces;

namespace Sales.DataLayer.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly ISalesContext _context;

        public BookRepository(ISalesContext context)
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
            _context.Books.Add(book);

            await _context.SaveChanges();
        }
        public async Task<Book> Edit(Guid? id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }
        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);

            await _context.SaveChanges();

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

            await _context.SaveChanges();
        }
        public async Task<bool> BookExists(Guid id)
        {
            var bookExists = await _context.Books.AnyAsync(e => e.Id == id);

            return bookExists;
        }
    }
}
