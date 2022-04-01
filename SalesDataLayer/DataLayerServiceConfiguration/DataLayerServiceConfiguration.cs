using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Sales.DataLayer.Context;

namespace Sales.DataLayer.DataLayerServiceConfiguration
{
    public static class DataLayerServiceConfiguration
    {
        public static void AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SalesContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddScoped<IDataLayer, DataLayer>();
        }
    }
}
