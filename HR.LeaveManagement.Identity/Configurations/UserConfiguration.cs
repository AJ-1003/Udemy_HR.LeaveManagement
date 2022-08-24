using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "ff4b2a5c-f027-4ae4-a1e8-76ed3ca395c2",
                    Email = "admin@mail.com",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@mail.com",
                    NormalizedUserName = "ADMIN@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "123456"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "52902de6-aeb7-4df5-86e3-26e203b6ccc5",
                    Email = "user@mail.com",
                    NormalizedEmail = "USER@MAIL.COM",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@mail.com",
                    NormalizedUserName = "USER@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "123456"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
