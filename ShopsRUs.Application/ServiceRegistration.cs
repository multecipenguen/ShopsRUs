using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopsRUs.Application.Validation;
using System.Reflection;

namespace ShopsRUs.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
