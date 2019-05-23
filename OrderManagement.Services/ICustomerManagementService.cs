using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain;

namespace OrderManagement.Services
{
    public interface ICustomerManagementService
    {
        Task<List<Customer>> GetCustomersAsync();
    }
}