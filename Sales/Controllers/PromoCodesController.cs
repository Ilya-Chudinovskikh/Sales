using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.DataLayer.Entities;
using Sales.BusinessLayer.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Sales.App.Controllers
{
    public class PromoCodesController : Controller
    {
        private readonly IPromoCodeService _promoCodeService;
        private readonly IPromoCodeGenerator _promoCodeGenerator;

        public PromoCodesController(IPromoCodeService promoCodeService, IPromoCodeGenerator promoCodeGenerator)
        {
            _promoCodeService = promoCodeService;
            _promoCodeGenerator = promoCodeGenerator;
        }
        public async Task<IActionResult> GetPromoCode()
        {
            var code = _promoCodeGenerator.Promocode;

            await ApprovePromoCode(code);

            return View("Books/Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string code)
        {
            if (!(await _promoCodeService.PromoCodeIsNew(code)))
            {
                if (await _promoCodeService.PromoCodeIsValid(code))
                {
                    await ApprovePromoCode(code);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Authentication()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Code,IsValid")] PromoCode promoCode)
        {
            if (await _promoCodeService.PromoCodeIsNew(promoCode.Code))
            {
                await _promoCodeService.Register(promoCode);

                await Authenticate(promoCode.Code); 
            }

            else
            {
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction("Index", "Home");
        }
        private async Task Authenticate(string code)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, code)
            };

            var id = new ClaimsIdentity(claims, 
                "ApplicationCookie", 
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(id));
        }

        private async Task<IActionResult> ApprovePromoCode(string code)
        {
            await Authenticate(code);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Authentication", "PromoCodes");
        }
    }
}
