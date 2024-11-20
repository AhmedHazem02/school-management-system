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
    public class InstructorServices : IInstructorServices
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorServices(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public async Task<string> AddInstructorAsync(Instructor instructor)
        {
            try
            {
                await _instructorRepository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception )
            {
                return "FaildToAdd";
            }
             
        }

        public async Task<Instructor> GetInstructorById(int Ins_Id)
        {
            return await _instructorRepository.GetByIdAsync(Ins_Id);
        }

        public async Task<List<Instructor>> GetListOfInstructor()
        {
            return await _instructorRepository.GetAllInstructorAsync();
        }
    }
}
