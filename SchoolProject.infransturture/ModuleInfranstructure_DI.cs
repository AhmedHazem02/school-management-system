using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infransturture.Bases;
using SchoolProject.infransturture.Repository.Abstruct;
using SchoolProject.infransturture.Repository.Impelement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infransturture
{
    public static class ModuleInfranstructure_DI
    {
        public static IServiceCollection AddModuleInfranstructure_ID(this IServiceCollection services){

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
