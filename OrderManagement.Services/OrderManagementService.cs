using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.DataAccess.InMemory;
using OrderManagement.Domain;

namespace OrderManagement.Services
{
    internal class OrderManagementService : IOrderManagementService
    {
        private readonly IOrdersRepository _repository;

        public OrderManagementService(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return _repository.GetOrdersAsync();
        }

        public Task<bool> CreateOrderAsync(Order order)
        {
            return _repository.CreateOrderAsync(order);
        }
    }
}
