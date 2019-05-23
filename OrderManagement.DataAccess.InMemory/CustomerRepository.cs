using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderManagement.Domain;

namespace OrderManagement.DataAccess.InMemory
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly MyShopDbConfig _config;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(MyShopDbConfig config, ILogger<CustomerRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            var customer = new Customer
            {
                Name = _config?.ConnectionString
            };

            return Task.FromResult(new List<Customer>(new[] {customer}));
        }
    }
}