using Sales.DataLayer.Entities;
using Sales.DataLayer.Interfaces;
using System.Threading.Tasks;

namespace Sales.DataLayer.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private readonly ISalesContext _context;

        public OrderRepository(ISalesContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);

            await _context.SaveChanges();
        }
        public async Task UpdateOrder(Order updatedOrder)
        {
            _context.Orders.Update(updatedOrder);

            await _context.SaveChanges();
        }
    }
}
