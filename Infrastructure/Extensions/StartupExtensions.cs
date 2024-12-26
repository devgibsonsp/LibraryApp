using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using System.Reflection;
using Infrastructure.Repositories;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped<ILibraryReadRepository, LibraryReadRepository>();

            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}