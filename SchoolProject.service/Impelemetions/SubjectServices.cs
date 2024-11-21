using SchoolProject.Data.Entites;
using SchoolProject.infransturture.Repository.Abstruct;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subject = SchoolProject.Data.Entites.Subject;

namespace SchoolProject.service.Impelemetions
{
    public class SubjectServices : ISubjectServices
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectServices(ISubjectRepository subjectRepository)
        {
             _subjectRepository = subjectRepository;
        }

        public async Task<string> AddSubject(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
            return "Success";
        }

        public async Task<string> DeleteSubject(int id)
        {
            var Subject=await _subjectRepository.GetByIdAsync(id);
            if (Subject == null) return "NotFound";
            try
            {
                await _subjectRepository.DeleteAsync(Subject);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Faild";
            }
        }

        public async Task<string> EditCourse(Subject subject)
        {
            var Subject = await _subjectRepository.GetByIdAsync(subject.id);
            if (Subject == null) return "NotFound";
            try
            {
                await _subjectRepository.UpdateAsync(Subject);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Faild";
            }
        }

        public async Task<Subject> GetSubjectById(int id)
        {
           return await _subjectRepository.GetByIdAsync(id); 
        }

        public async  Task<IReadOnlyList<Subject>> GetSubjects()
        {
            return await _subjectRepository.GetSubjects();
        }
    }
}
