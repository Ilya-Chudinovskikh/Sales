using Sales.DataLayer.Entities;
using System.Threading.Tasks;

namespace Sales.DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order newOrder);
        Task UpdateOrder(Order updatedOrder);
    }
}
