using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Queries.DTOs
{
    public class UsersListPaginationDTO
    {
        public string UserName {  get; set; }
        public string DisplayName {  get; set; }

        public string Email {  get; set; }
    }
}
