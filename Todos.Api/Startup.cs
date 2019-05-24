using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todos.Api.Abstractions;
using Todos.Api.Configs;
using Todos.Api.DataAccess;
using Todos.Api.Services;

namespace Todos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            var dbConfig = new TodoDbConfig();
            Configuration.Bind("DbConfig", dbConfig);

            var apiConfig = new ExternalTodoApiConfig();
            Configuration.Bind("ApiConfig", apiConfig);


            services.AddSingleton(dbConfig);
            services.AddSingleton(apiConfig);
            services.AddSingleton<ITodoManagementService, TodoManagementService>();
            services.AddSingleton<ITodoRepository, FakeTodoRepository>();
            services.AddSingleton<IExternalTodoApi, FakeExternalTodoApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
