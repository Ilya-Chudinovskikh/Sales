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
        public virtual DbSet<PromoCode> PromoCodes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public SalesContext()
        {
        }
    }
}
