using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.infransturture.Repository.Abstruct;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Impelemetions
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<string> AddDepartment(Department department)
        {
             await _departmentRepository.AddAsync(department);
            return "Success";
        }

        public async  Task<string> EditDepartment(Department department)
        {
             await _departmentRepository.UpdateAsync(department);
            return "Success";
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
           var Dept= await _departmentRepository.GetTableNoTracking().Where(x => x.id.Equals(id))
                                 .Include(x => x.Instructors)
                                 .Include(x => x.DepartmentSubjects).ThenInclude(x=>x.Subject)
                                 .Include(x => x.Students)
                                 .Include(x=>x.Instructor).FirstOrDefaultAsync();
            return Dept;
            
              
        }

        public async Task<Department> GetDepartmentByIdAsyncNotInclude(int DID)
        {
            return await _departmentRepository.GetByIdAsync(DID);
        }

        public async Task<bool> IsDepartmentExist(int DID)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.id.Equals(DID));
        }

        public async Task<bool> IsNameExist(string name)
        {
            return await _departmentRepository.GetTableNoTracking().AllAsync(x=>x.DName.Equals(name));
        }
    }
}
