
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Identity
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userId = "017b2cdc-4bf2-11ea-b77f-2e728ce88125";
            var roleId = "017b520c-4bf2-11ea-b77f-2e728ce88125";
            var role = new IdentityRole
            {
                Id = roleId,
                Name = "Admin Role",
                NormalizedName = "Admin Role"
            };
            builder.Entity<IdentityRole>().HasData(role);

            var user =new IdentityUser
            {
                Id= userId,
                UserName="Admin",
                PasswordHash="Admin "
            };
            builder.Entity<IdentityUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = roleId
            });
        }
    }
}
