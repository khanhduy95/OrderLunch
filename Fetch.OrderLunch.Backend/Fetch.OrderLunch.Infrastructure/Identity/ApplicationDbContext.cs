
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
            var MemberRoleId = "0a89e59c-4c20-11ea-b77f-2e728ce88125";
            var AdminRoleId = "17eb914a-4c20-11ea-b77f-2e728ce88125";

            var user = new IdentityUser
            {
                Id = userId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN"
            };

            var claims = new List<IdentityUserClaim<string>>()
            {
                new IdentityUserClaim<string>()
                {
                    Id=1,
                    UserId="017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                    ClaimType="Role Edit",
                    ClaimValue="true"
                },

                 new IdentityUserClaim<string>()
                {
                    Id=2,
                    UserId="017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                    ClaimType="Delete Edit",
                    ClaimValue="true"
                },

                  new IdentityUserClaim<string>()
                {
                    Id=3,
                    UserId="017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                    ClaimType="Create Edit",
                    ClaimValue="true"
                },

            };

            var userRole = new IdentityUserRole<string>
            {
                UserId = "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                RoleId = "17eb914a-4c20-11ea-b77f-2e728ce88125"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin");

            builder.Entity<IdentityUser>().HasData(user);

            builder.Entity<IdentityRole>()
                  .HasData(
                       new IdentityRole
                       {
                           Id = AdminRoleId,
                           Name = "Admin",
                           NormalizedName = "Admin"
                       },
                       new IdentityRole
                       {
                           Id = MemberRoleId,
                           Name = "Member",
                           NormalizedName = "Member"
                       }
                   );

            builder.Entity<IdentityUserRole<string>>().HasData(userRole);

            builder.Entity<IdentityUserClaim<string>>()
                   .HasData(claims);

        }
    }
}
