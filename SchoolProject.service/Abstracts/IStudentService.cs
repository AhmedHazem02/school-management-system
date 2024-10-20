using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public IQueryable <Student> GetStudentsQuerable();
        public Task<Student>GetStudentByIdAsync(int id);
        public Task<Student>GetStudentByIdWithoutIncludedAsync(int id);
        public Task<string> AddNewStudent(Student student);
        public Task <bool>IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name,int id);

        public Task <string> EditStudentAsync(Student student);
        public Task <string> DeleteStudentAsync(Student student);
        public IQueryable<Student> GetStudentsSearchQuerable(string search);
    }
}
