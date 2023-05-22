using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FOS_L1_201945D.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
