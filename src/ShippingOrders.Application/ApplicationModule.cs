using Microsoft.Extensions.DependencyInjection;
using ShippingOrders.Application.Services;

namespace ShippingOrders.Application
{

    // Essa classe serve para ser como injeção de dependência da camada de application. Cada camada terá um module para dependências
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IShippingOrderService, ShippingOrderService>();
            services.AddScoped<IShippingServiceService, ShippingServiceService>();
            return services;
        }

    }
}
