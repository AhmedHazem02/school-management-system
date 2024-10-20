﻿using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
    }
}
