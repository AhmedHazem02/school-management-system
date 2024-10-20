using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.DTOs;
using SchoolProject.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentListPagination:IRequest<PaginatedResult<StudentListPaginationDTO>>
    {

        public int PageIndex { get; set; }
        public int PagerSize { get; set; }
        public string[]?OrderBy { get; set; }
        public string? Search {  get; set; }

    }
}
