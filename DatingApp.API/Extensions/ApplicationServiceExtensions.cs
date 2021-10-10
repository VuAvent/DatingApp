using System;
using DatingApp.API.Database.Repository;
using DatingApp.API.Profiles;
using DatingApp.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Namespace;
namespace DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            var connectionString = "server=localhost;user=root;password=1111;database=DatingApp";
            services.AddDbContext<DataContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );
            services.AddScoped<ITokenServices, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);
            return services;
        }

    }
}