using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.Api.Domain.Models;

namespace Todos.Api.Abstractions
{
    public interface ITodoManagementService
    {
        Task<List<Todo>> GetTodosAsync();
    }
}