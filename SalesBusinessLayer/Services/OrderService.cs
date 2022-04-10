using Sales.BusinessLayer.Interfaces;
using Sales.DataLayer.Entities;
using Sales.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BusinessLayer.Services
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task CreateOrder(Book book, PromoCode promoCode)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                PromoCode = promoCode,
                OrderedBooks = new List<Book> { book },
                TotalSum = book.Cost,
                IsConfirmed = false
            };

            var result = _orderRepository.CreateOrder(newOrder);

            return result;
        }
        public Task AddBook(Book book, Order order)
        {
            order.OrderedBooks.Add(book);

            var updatedOrder = _orderRepository.UpdateOrder(order);

            return updatedOrder;
        }
        public Task DeleteBook(Book book, Order order)
        {
            order.OrderedBooks.Remove(book);

            var updatedOrder = _orderRepository.UpdateOrder(order);

            return updatedOrder;
        }
        public Task ConfirmOrder(Order order)
        {
            order.IsConfirmed = true;

            var updatedOrder = _orderRepository.UpdateOrder(order);

            return updatedOrder;
        }
    }
}
