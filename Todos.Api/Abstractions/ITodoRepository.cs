using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.Api.Domain.Models;

namespace Todos.Api.Abstractions
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodosAsync();
    }
}
