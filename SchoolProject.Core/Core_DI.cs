using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using SchoolProject.service.Abstracts;
using SchoolProject.service.Impelemetions;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class Core_DI
    {
        public static IServiceCollection AddCore_DI(this IServiceCollection services)
        {
            // Configration Of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configration Of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Configration Of FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
