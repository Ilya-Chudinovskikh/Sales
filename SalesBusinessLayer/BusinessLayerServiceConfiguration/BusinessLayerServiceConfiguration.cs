using Microsoft.Extensions.DependencyInjection;
using Sales.BusinessLayer.Interfaces;
using Sales.BusinessLayer.Services;

namespace Sales.BusinessLayer.BusinessLayerServiceConfiguration
{
    public static class BusinessLayerServiceConfiguration
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IPromoCodeService, PromoCodeService>();

            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
