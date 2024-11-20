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
    public class InstructorRepository : GenericRepository<Instructor>,IInstructorRepository
    {
        private readonly DbSet<Instructor> _instructor;

        public InstructorRepository(AppDbContext dbContext) : base(dbContext)
        {
            _instructor = dbContext.Set<Instructor>();
        }

        public async Task<List<Instructor>> GetAllInstructorAsync()
        {
            return await _instructor.ToListAsync();
        }
    }
}
