using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.DataAccess.InMemory;
using OrderManagement.Domain;
using OrderManagement.Shipping.Api;

namespace OrderManagement.Services
{
    internal class CustomerManagementService : ICustomerManagementService
    {
        private readonly ICustomerRepository _repository;
        private readonly IExternalCustomersApi _shippingService;

        public CustomerManagementService(ICustomerRepository repository, IExternalCustomersApi shippingService)
        {
            _repository = repository;
            _shippingService = shippingService;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customersFromDatabase = await _repository.GetCustomersAsync();
            var customersFromService = await _shippingService.GetCustomersAsync();

            var allCustomers = new List<Customer>(customersFromDatabase);
            allCustomers.AddRange(customersFromService);

            return allCustomers;
        }
    }
}
