using Sales.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataLayer.Interfaces
{
    public interface IPromoCodeRepository
    {
        Task Register(PromoCode promoCode);
        Task<bool> PromoCodeIsNew(string code);
        Task<bool> PromoCodeIsValid(string code);
        Task UpdatePromoCode(PromoCode updatedPromoCode);
    }
}
