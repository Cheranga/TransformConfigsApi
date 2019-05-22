using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain;

namespace OrderManagement.DataAccess.InMemory
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<bool> CreateOrderAsync(Order order);
    }
}
