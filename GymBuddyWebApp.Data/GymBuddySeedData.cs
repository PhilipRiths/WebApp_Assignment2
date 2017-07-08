using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GymBuddyWebApp.Domain;
using Microsoft.AspNetCore.Identity;

namespace GymBuddyWebApp.Data
{
    public class GymBuddySeedData
    {
        private GymBuddyContext _context;
        private UserManager<ApplicationUser> _userManager;

        public GymBuddySeedData(GymBuddyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("admin@hotmail.se") == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@hotmail.se",
                    Email = "admin@hotmail.se"
                };
                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }
        }
    }
}
