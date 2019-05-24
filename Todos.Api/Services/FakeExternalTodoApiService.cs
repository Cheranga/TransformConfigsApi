using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.Api.Abstractions;
using Todos.Api.Configs;
using Todos.Api.Domain.Models;

namespace Todos.Api.Services
{
    internal class FakeExternalTodoApiService : IExternalTodoApi
    {
        private readonly ExternalTodoApiConfig _config;

        public FakeExternalTodoApiService(ExternalTodoApiConfig config)
        {
            _config = config;
        }


        public Task<List<Todo>> GetTodosAsync()
        {
            return Task.FromResult(new List<Todo>(new[]
            {
                new Todo
                {
                    Title = _config?.Url
                }
            }));
        }
    }
}