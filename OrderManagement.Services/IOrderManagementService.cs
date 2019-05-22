using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain;

namespace OrderManagement.Services
{
    public interface IOrderManagementService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<bool> CreateOrderAsync(Order order);
    }
}