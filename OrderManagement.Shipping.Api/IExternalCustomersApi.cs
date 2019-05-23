using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain;

namespace OrderManagement.Shipping.Api
{
    public interface IExternalCustomersApi
    {
        Task<List<Customer>> GetCustomersAsync();
    }
}