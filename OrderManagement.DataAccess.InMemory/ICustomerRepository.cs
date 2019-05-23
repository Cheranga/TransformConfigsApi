using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain;

namespace OrderManagement.DataAccess.InMemory
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
    }
}
