using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IInstructorServices
    {
        public Task<string> AddInstructorAsync(Instructor instructor);
        public Task<List<Instructor>>GetListOfInstructor();
    }
}
