using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface ISubjectServices
    {
        public Task<string> AddSubject(Subject subject);
        public Task<string> DeleteSubject(int id);
        public Task<Subject> GetSubjectById(int id);
        public Task<IReadOnlyList<Subject>> GetSubjects();

        public Task<string> EditCourse(Subject subject);
    }
}
