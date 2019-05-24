using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todos.Api.Abstractions;

namespace Todos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoManagementService _orderManagementService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodoManagementService orderManagementService, ILogger<TodosController> logger)
        {
            _orderManagementService = orderManagementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting orders");
            var orders = await _orderManagementService.GetTodosAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }
    }
}