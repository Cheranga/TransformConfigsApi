using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Domain;
using OrderManagement.Services;
using OrderManagement.Shipping.Api;

namespace OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICustomerManagementService _orderManagementService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ICustomerManagementService orderManagementService, ILogger<OrdersController> logger)
        {
            _orderManagementService = orderManagementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting orders");
            var orders = await _orderManagementService.GetCustomersAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }
    }
}