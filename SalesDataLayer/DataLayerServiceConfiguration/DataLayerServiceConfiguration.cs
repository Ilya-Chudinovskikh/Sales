using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Sales.DataLayer.Context;
using Sales.DataLayer.Interfaces;
using Sales.DataLayer.Repositories;

namespace Sales.DataLayer.DataLayerServiceConfiguration
{
    public static class DataLayerServiceConfiguration
    {
        public static void AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SalesContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddScoped<ISalesContext, SalesContext>();

            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
