using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Entities;
using Sales.DataLayer.Interfaces;
using System.Threading.Tasks;

namespace Sales.DataLayer.Context
{
    public class SalesContext : DbContext, ISalesContext
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
        public async Task SaveChanges()
        {
            await base.SaveChangesAsync();
        }
    }
}
