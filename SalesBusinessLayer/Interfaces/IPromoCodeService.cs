using Sales.DataLayer.Entities;
using System.Threading.Tasks;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IPromoCodeService
    {
        Task Register(PromoCode promoCode);
        Task<bool> PromoCodeIsNew(string code);
        Task<bool> PromoCodeIsValid(string code);
        Task UsePromoCode(PromoCode promoCode);
    }
}
