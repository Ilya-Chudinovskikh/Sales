using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.DataLayer.Context;
using Sales.DataLayer.Entities;
using System;
using System.Linq;

namespace Sales.DataLayer.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SalesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SalesContext>>());

            if (context.Books.Any())
            {
                return;
            }

            context.Books.AddRange(
                new Book
                {
                    Name = "War and Peace",
                    Author = "Lev Nikolaevich Tolstoy",
                    Year = 2007,
                    IsbnCode = "978-5-699-13659-9",
                    Picture = "*picture*",
                    Cost = 500.0,
                    Amount = 10
                },

                new Book
                {
                    Name = "Crime and Punishment",
                    Author = "Fyodor Mikhailovich Dostoevsky",
                    Year = 2008,
                    IsbnCode = "978-5-358-05901-6",
                    Picture = "*picture*",
                    Cost = 400.0,
                    Amount = 15
                }
            );
            context.SaveChanges();
        }
    }
}
