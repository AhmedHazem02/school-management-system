using MimeKit.Tnef;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<bool> IsDepartmentExist(int DID);
        public Task<string>EditDepartment(Department department);
        public Task<Department> GetDepartmentByIdAsyncNotInclude(int DID);
        public Task<bool>IsNameExist(string name);
        public Task<string>AddDepartment(Department department);
    }
}
