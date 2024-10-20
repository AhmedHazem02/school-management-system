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
    public class StudentRepository :GenericRepository<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(AppDbContext dbContext):base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
           return await _students.Include(x=>x.Department).ToListAsync();
        }
    }
}
