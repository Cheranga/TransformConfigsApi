using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.Api.Abstractions;
using Todos.Api.Domain.Models;

namespace Todos.Api.Services
{
    internal class TodoManagementService : ITodoManagementService
    {
        private readonly ITodoRepository _repository;
        private readonly IExternalTodoApi _externalTodoService;

        public TodoManagementService(ITodoRepository repository, IExternalTodoApi externalTodoService)
        {
            _repository = repository;
            _externalTodoService = externalTodoService;
        }

        public async Task<List<Todo>> GetTodosAsync()
        {
            var todosFromDatabase = await _repository.GetTodosAsync();
            var todosFromService = await _externalTodoService.GetTodosAsync();

            var allTodos = new List<Todo>(todosFromDatabase);
            allTodos.AddRange(todosFromService);

            return allTodos;
        }
    }
}
