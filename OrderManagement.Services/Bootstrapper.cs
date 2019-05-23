using Microsoft.Extensions.DependencyInjection;
using OrderManagement.DataAccess.InMemory;

namespace OrderManagement.Services
{
    public static class Bootstrapper
    {
        public static void UseCustomerManagementServices(this IServiceCollection services)
        {
            if (services == null)
            {
                return;
            }

            services.AddSingleton<ICustomerManagementService, CustomerManagementService>();
        }
    }
}
