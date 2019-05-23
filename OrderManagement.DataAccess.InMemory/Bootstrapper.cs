﻿using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.DataAccess.InMemory
{
    public static class Bootstrapper
    {
        public static void UseFakeCustomerDataAccess(this IServiceCollection services, MyShopDbConfig config)
        {
            if (services == null)
            {
                return;
            }

            services.AddSingleton(config);
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }
    }
}
