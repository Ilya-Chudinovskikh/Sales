using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.BusinessLayer.Interfaces;
using Sales.DataLayer.Entities;

namespace Sales.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPromoCodeService _promoCodeService;
        private readonly IBookService _bookService;

        public OrdersController(IOrderService orderService, IPromoCodeService promoCodeService, IBookService bookService)
        {
            _orderService = orderService;
            _promoCodeService = promoCodeService;
            _bookService = bookService;
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
            await _bookService.ReserveBook(book);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(Book book, Order order)
        {
            await _orderService.DeleteBook(book, order);
            await _bookService.ReturnBook(book);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOrder(Order order, PromoCode promoCode)
        {
            await _orderService.ConfirmOrder(order);
            await _promoCodeService.UsePromoCode(promoCode);

            return View(order);
        }
    }
}
