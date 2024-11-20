using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.MetaDataApp
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public static class StudentRouting
        {
            public const string perfix = Rule + "Student";
            public const string List = perfix + "/List";
            public const string GetById = perfix + "/{Id}";
            public const string Create = perfix + "/create";
            public const string Edit = perfix + "/edit";
            public const string Delete = perfix + "/{id}";
            public const string Pagination = perfix + "/pagination";
        }

        public static class DepartmentRouting {
            public const string perfix = Rule + "Department";
            public const string GetById = perfix + "/{Id}";
            public const string Edit = perfix + "/edit";
            public const string Create = perfix + "/create";
        }

        public static class AppUserRouting
        {
            public const string perfix = Rule + "AppUser";
            public const string Create = perfix + "/create";
            public const string List = perfix + "/List";
            public const string GetUserByUserName = perfix + "/{UserName}";
            public const string Edit = perfix + "/edit";
            public const string DeleteUser = perfix + "/{UserName}";
            public const string ChangePassword = perfix + "/changepassword";

        }

        public static class Authentication
        {
            public const string perfix = Rule + "authentication";
            public const string SignIn = perfix + "/sign_in";
            public const string ConfirmeEmail = perfix + "/ConfirmeEmail";


        }

        public static class Instructor
        {
            public const string perfix = Rule + "instructor";
            public const string Create = perfix + "/create";
            public const string GetAllInstructor = perfix + "/allInstructor";
            public const string GetById = perfix + "/{Id}";

        }

        public static class Authorization
        {
            public const string perfix = Rule + "authorization";
            public const string Create = perfix + "/create";
            public const string Edit = perfix + "/edit";
            public const string Delete = perfix + "/delete/{RoleId}";
            public const string GetRoleById = perfix + "/GetRoleById/{RoleId}";
            public const string GetListOfRole = perfix + "/GetListOfRole";
            public const string GetManageUserRole = perfix + "/GetManageUserRole/{UserId}";
            public const string UpdateUserRole = perfix + "/UpdateUserRole";

        }
        public static class Email
        {
            public const string perfix = Rule + "Email";
            public const string SendEmail = perfix + "/SendEmail";
        }

    }
}
