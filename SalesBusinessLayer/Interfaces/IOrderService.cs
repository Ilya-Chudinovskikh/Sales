using Sales.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IOrderService
    {
        public Task CreateOrder(Book book, PromoCode promoCode);
        public Task AddBook(Book book, Order order);
        public Task DeleteBook(Book book, Order order);
        public Task ConfirmOrder(Order order);
    }
}
