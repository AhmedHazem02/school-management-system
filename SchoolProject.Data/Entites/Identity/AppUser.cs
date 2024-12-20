﻿using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites.Identity
{
    public class AppUser:IdentityUser
    {
        public string DisplayName {  get; set; }
        [EncryptColumn]
        public string? Code { get; set; }

    }
}
