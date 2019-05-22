using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderManagement.Domain;

namespace OrderManagement.DataAccess.InMemory
{
    internal class OrderRepository : IOrdersRepository
    {
        private readonly OrdersDbConfig _config;
        private readonly ILogger<OrderRepository> _logger;

        private readonly List<Order> _orders;

        public OrderRepository(OrdersDbConfig config, ILogger<OrderRepository> logger)
        {
            _config = config;
            _logger = logger;
            _orders = new List<Order>();

            _logger.LogInformation($"Order repository instantiated: {config?.ConnectionString}");
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            _logger.LogInformation("Retrieving orders from the data access layer");
            return Task.FromResult(_orders);
        }

        public Task<bool> CreateOrderAsync(Order order)
        {
            if (order == null)
            {
                return Task.FromResult(false);
            }

            _orders.Add(order);

            return Task.FromResult(true);
        }
    }
}