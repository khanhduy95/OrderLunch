using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Infrastructure
{
    public class IdentitySeed
    {
        public void UserAndRoleDataInitializer(UserManager<IdentityUser> userManager,
                                               RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("Admin@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin@123").Result;

               
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddClaimAsync(user, new Claim("Edit", "Admin"));
                }
            }
        }
        private void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}       
    

