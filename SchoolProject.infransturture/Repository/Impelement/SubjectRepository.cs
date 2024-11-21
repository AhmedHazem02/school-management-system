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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly DbSet<Subject> _subject;

        public SubjectRepository(AppDbContext dbContext) : base(dbContext)
        {
            _subject = dbContext.Set<Subject>();
        }

        public async Task<IReadOnlyList<Subject>> GetSubjects()
        {
            return await _subject.ToListAsync();
        }
    }
}
