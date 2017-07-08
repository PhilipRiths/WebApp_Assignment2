using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymBuddyWebApp.Domain
{
    public class ApplicationUser : IdentityUser
    {
     public int Age { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }        
    }
}