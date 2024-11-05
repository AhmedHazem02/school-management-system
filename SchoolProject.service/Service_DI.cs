using Microsoft.Extensions.DependencyInjection;
using SchoolProject.service.Abstracts;
using SchoolProject.service.Impelemetions;

namespace SchoolProject.service
{
    public static class Service_DI
    {
        public static IServiceCollection Addservices_DI(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            return services;
        }
    }
}
