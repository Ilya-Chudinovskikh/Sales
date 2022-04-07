using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Context;
using Sales.DataLayer.Entities;
using Sales.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataLayer.Repositories
{
    class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly ISalesContext _context;
        public PromoCodeRepository(ISalesContext context)
        {
            _context = context;
        }
        public async Task Register(PromoCode promoCode)
        {
            _context.PromoCodes.Add(promoCode);

            await _context.SaveChanges();
        }
        public async Task<bool> PromoCodeIsNew(string code)
        {
            var isNew = !(await _context.PromoCodes.AnyAsync(pc=>pc.Code==code));

            return isNew;
        }
        public async Task<bool> PromoCodeIsValid(string code)
        {
            var promoCode = await _context.PromoCodes
                .FirstOrDefaultAsync(pc => pc.Code == code);

            var isValid = promoCode.IsValid;

            return isValid;
        }
    }
}
