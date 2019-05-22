using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.Services
{
    public static class Bootstrapper
    {
        public static void UseOrderManagementServices(this IServiceCollection services)
        {
            services?.AddScoped<IOrderManagementService, OrderManagementService>();
        }
    }
}
