using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolProject.Data.Entites;
using SchoolProject.infransturture.Repository.Abstruct;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Impelemetions
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
              _studentRepository = studentRepository;
        }

       

        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            var res = _studentRepository.GetTableNoTracking()
                                      .Include(x => x.Department)
                                      .Where(x => x.id.Equals(Id))
                                      .FirstOrDefault();
            return res;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }
        public async Task<string> AddNewStudent(Student student)
        {
            
           await _studentRepository.AddAsync(student);
            return "Sucess";
        }
        public async Task<bool> IsNameExist(string name)
        {
            var Res = _studentRepository.GetTableNoTracking().Where(x => x.name.Equals(name)).FirstOrDefault();
            if (Res == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var Res =await _studentRepository.GetTableNoTracking().Where(x => x.name.Equals(name)&!x.id.Equals(id)).FirstOrDefaultAsync();
            if (Res == null) return false;
            return true;
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            var tran=_studentRepository.Transaction();
            try
            {
                 await _studentRepository.DeleteAsync(student);
               await tran.CommitAsync();
                 return "Success";
            }
            catch 
            {
               await tran.RollbackAsync();
                return "Fail";
            }
           
        }

        public async Task<Student> GetStudentByIdWithoutIncludedAsync(int id)
        {
            var res =  _studentRepository.GetTableNoTracking()
                                       .Where(x => x.id.Equals(id))
                                       .FirstOrDefault();
            return res;
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return  _studentRepository.GetTableNoTracking().Include(x=>x.Department);
        }

        public IQueryable<Student> GetStudentsSearchQuerable(string search)
        {
             var res= _studentRepository.GetTableNoTracking().Include(x => x.Department);
            if(search != null)
            {
                var Sr = res.Where(x => x.name.Contains(search) || x.Address.Contains(search));
                return Sr;
            }
            return res;
        }
    }
}
