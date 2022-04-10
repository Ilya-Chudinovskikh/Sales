using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales.BusinessLayer.Interfaces;
using Sales.DataLayer.Context;
using Sales.DataLayer.Entities;

namespace Sales.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(Book book, PromoCode promoCode)
        {
            await _orderService.CreateOrder(book, promoCode);

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(Book book, Order order)
        {
            await _orderService.AddBook(book, order);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(Book book, Order order)
        {
            await _orderService.DeleteBook(book, order);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOrder(Order order)
        {
            await _orderService.ConfirmOrder(order);

            return View(order);
        }
    }
}
