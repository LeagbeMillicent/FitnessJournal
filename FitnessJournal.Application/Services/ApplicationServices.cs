using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FitnessJournal.Application.Services
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
