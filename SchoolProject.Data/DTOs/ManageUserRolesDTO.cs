using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.DTOs
{
    public class ManageUserRolesDTO
    {
        public string UserId {  get; set; }
        public List<Roles> role { get; set; }
    }
    public class Roles
    {
        public string RoleId {  get; set; }
        public string RoleName { get; set; }
        public bool HasRole {  get; set; }
    }
}
