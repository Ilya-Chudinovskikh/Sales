using Sales.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BusinessLayer.Services
{
    public class PromoCodeGenerator : IPromoCodeGenerator
    {
        public string Promocode { get { return GeneratePromoCode(); } }

        private readonly static Random _random = new();
        private static string GeneratePromoCode()
        {
            var source = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var codeBuilder = new StringBuilder(6);

            for (int i = 0; i < 7; i++)
            {
                var symbol = source[_random.Next(source.Length)];

                codeBuilder.Append(symbol);
            }

            var code = codeBuilder.ToString();

            return code;
        }
    }
}
