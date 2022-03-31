using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Entities;

namespace Sales.DataLayer.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext (DbContextOptions<SalesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public SalesContext()
        {
        }
    }
}
