using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todos.Api.Abstractions;

namespace Todos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoManagementService _todoManagementService;

        public TodosController(ITodoManagementService todoManagementService)
        {
            _todoManagementService = todoManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _todoManagementService.GetTodosAsync();

            if (todos == null || !todos.Any())
            {
                return NotFound();
            }

            return Ok(todos);
        }
    }
}