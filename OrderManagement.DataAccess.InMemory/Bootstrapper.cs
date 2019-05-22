using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.DataAccess.InMemory
{
    public static class Bootstrapper
    {
        public static void UseInMemoryDataAccess(this IServiceCollection services, OrdersDbConfig config)
        {
            if (services == null)
            {
                return;
            }

            services.AddSingleton(config);
            services.AddSingleton<IOrdersRepository, OrderRepository>();
        }
    }
}
