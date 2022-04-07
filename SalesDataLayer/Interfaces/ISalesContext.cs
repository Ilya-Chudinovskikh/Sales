using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Entities;
using System.Threading.Tasks;

namespace Sales.DataLayer.Interfaces
{
    public interface ISalesContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<PromoCode> PromoCodes { get; set; }
        DbSet<Order> Orders { get; set; }
        Task SaveChanges();
    }
}
