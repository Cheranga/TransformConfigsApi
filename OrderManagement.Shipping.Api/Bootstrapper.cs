using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.Shipping.Api
{
    public static class Bootstrapper
    {
        public static void UseExternalCustomersApi(this IServiceCollection services, ExternalCustomersApiConfig config)
        {
            if (services == null)
            {
                return;
            }

            services.AddSingleton(config);
            services.AddSingleton<IExternalCustomersApi, ExternalCustomersApiService>();
        }
    }
}