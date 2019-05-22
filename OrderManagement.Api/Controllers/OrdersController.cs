using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Domain;
using OrderManagement.Services;

namespace OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManagementService _service;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderManagementService service, ILogger<OrdersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting orders");
            var orders = await _service.GetOrdersAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order order)
        {
            var status = await _service.CreateOrderAsync(order);

            if (status)
            {
                return Ok();
            }

            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
    }
}