using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queries.DTOs;
using SchoolProject.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Queries.Models
{
    public class GetUsersListPagination:IRequest<PaginatedResult<UsersListPaginationDTO>>
    {
        public int PageIndex { get; set; }
        public int PageSize {  get; set; }
    }
}
