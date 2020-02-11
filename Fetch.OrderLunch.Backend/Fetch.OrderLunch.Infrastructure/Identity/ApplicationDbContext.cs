
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

            builder.Entity<IdentityRole>()
                   .HasData(
                        new IdentityRole 
                           {
                               Id= AdminRoleId,
                               Name="Admin",
                               NormalizedName="Admin"
                           },
                        new IdentityRole
                        {
                            Id = MemberRoleId,
                            Name = "Member",
                            NormalizedName = "Member"
                        }
                    );

            var user =new IdentityUser
            {
                Id= userId,
                UserName="Admin",
                NormalizedUserName="ADMIN"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin");

            builder.Entity<IdentityUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>()
                   .HasData(
                            new IdentityUserRole<string>
                            {
                                UserId = userId,
                                RoleId = AdminRoleId
                            });
        }
    }
}
