using Microsoft.Extensions.DependencyInjection;

namespace Sales.BusinessLayer.BusinessLayerServiceConfiguration
{
    public static class BusinessLayerServiceConfiguration
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IBusinessLayer, BusinessLayer>();
        }
    }
}
