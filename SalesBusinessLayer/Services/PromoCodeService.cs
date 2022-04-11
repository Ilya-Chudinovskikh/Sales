using Sales.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.DataLayer.Interfaces;
using Sales.DataLayer.Entities;

namespace Sales.BusinessLayer.Services
{
    class PromoCodeService : IPromoCodeService
    {
        private readonly IPromoCodeRepository _promoCodeRepository;
        public PromoCodeService(IPromoCodeRepository promoCodeRepository)
        {
            _promoCodeRepository = promoCodeRepository;
        }
        public Task Register(PromoCode promoCode)
        {
            promoCode.Id = Guid.NewGuid();
            promoCode.IsValid = true;

            var result = _promoCodeRepository.Register(promoCode);

            return result;
        }
        public Task<bool> PromoCodeIsNew(string code)
        {
            var isNew = _promoCodeRepository.PromoCodeIsNew(code);

            return isNew;
        }
        public Task<bool> PromoCodeIsValid(string code)
        {
            var isValid = _promoCodeRepository.PromoCodeIsValid(code);

            return isValid;
        }
        public Task UsePromoCode(PromoCode promoCode)
        {
            promoCode.IsValid = false;

            return _promoCodeRepository.UpdatePromoCode(promoCode);
        }
    }
}