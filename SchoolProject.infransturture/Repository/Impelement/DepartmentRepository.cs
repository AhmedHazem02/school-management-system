using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.infransturture.Bases;
using SchoolProject.infransturture.Data;
using SchoolProject.infransturture.Repository.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infransturture.Repository.Impelement
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _department;

        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _department = dbContext.Set<Department>();
        }
    }
}
