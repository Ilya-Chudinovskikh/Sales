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
    //    public static void Initialize(IServiceProvider serviceProvider)
    //    {
    //        using (var context = new SalesContext(
    //            serviceProvider.GetRequiredService<
    //                DbContextOptions<SalesContext>>()))
    //        {
    //            // Look for any movies.
    //            if (context.Books.Any())
    //            {
    //                return;   // DB has been seeded
    //            }

    //            context.Books.AddRange(
    //                new Book
    //                {
    //                    Title = "When Harry Met Sally",
    //                    ReleaseDate = DateTime.Parse("1989-2-12"),
    //                    Genre = "Romantic Comedy",
    //                    Price = 7.99M
    //                },

    //                new Book
    //                {
    //                    Title = "Ghostbusters ",
    //                    ReleaseDate = DateTime.Parse("1984-3-13"),
    //                    Genre = "Comedy",
    //                    Price = 8.99M
    //                },

    //                new Book
    //                {
    //                    Title = "Ghostbusters 2",
    //                    ReleaseDate = DateTime.Parse("1986-2-23"),
    //                    Genre = "Comedy",
    //                    Price = 9.99M
    //                },

    //                new Book
    //                {
    //                    Title = "Rio Bravo",
    //                    ReleaseDate = DateTime.Parse("1959-4-15"),
    //                    Genre = "Western",
    //                    Price = 3.99M
    //                }
    //            );
    //            context.SaveChanges();
    //        }
    //    }
    }
}
