using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain;

namespace OrderManagement.Shipping.Api
{
    internal class ExternalCustomersApiService : IExternalCustomersApi
    {
        private readonly ExternalCustomersApiConfig _config;

        public ExternalCustomersApiService(ExternalCustomersApiConfig config)
        {
            _config = config;
        }


        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(new List<Customer>(new[]
            {
                new Customer
                {
                    Name = _config?.Url
                }
            }));
        }
    }
}