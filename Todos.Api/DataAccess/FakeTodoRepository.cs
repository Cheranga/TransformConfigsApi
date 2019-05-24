using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.Api.Abstractions;
using Todos.Api.Configs;
using Todos.Api.Domain.Models;

namespace Todos.Api.DataAccess
{
    internal class FakeTodoRepository : ITodoRepository
    {
        private readonly TodoDbConfig _config;

        public FakeTodoRepository(TodoDbConfig config)
        {
            _config = config;
        }

        public Task<List<Todo>> GetTodosAsync()
        {
            var task = new Todo
            {
                Title = _config?.ConnectionString
            };

            return Task.FromResult(new List<Todo>(new[] {task}));
        }
    }
}