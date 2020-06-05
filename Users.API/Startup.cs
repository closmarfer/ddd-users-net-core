using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Users.API.Application.Commands.CreateUser;
using Users.API.Application.Commands.DeleteUser;
using Users.API.Application.Commands.UpdatePassword;
using Users.API.Application.Commands.UpdateUser;
using Users.API.Application.Queries.Login;
using Users.Domain.Contract;
using Users.Domain.Service;
using Users.Infrastructure.Repository.MySQL;

namespace Users.API
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
            services.AddControllers();

            RegisterDomainServices(services);

            RegisterQueryHandlers(services);

            RegisterCommandHandlers(services);

            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton(typeof(MySqlProvider), typeof(MySqlProvider));

            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(Login));
            services.AddSingleton(typeof(HashPassword));
            services.AddSingleton(typeof(CreateUser));
            services.AddSingleton(typeof(DeleteUser));
            services.AddSingleton(typeof(UpdatePassword));
            services.AddSingleton(typeof(UpdateUser));
        }

        private static void RegisterQueryHandlers(IServiceCollection services)
        {
            services.AddSingleton(typeof(LoginQueryHandler));
        }

        private static void RegisterCommandHandlers(IServiceCollection services)
        {
            services.AddSingleton(typeof(CreateUserCommandHandler));
            services.AddSingleton(typeof(DeleteUserCommandHandler));
            services.AddSingleton(typeof(UpdatePasswordCommandHandler));
            services.AddSingleton(typeof(UpdateUserCommandHandler));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}