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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4bd5bce7-6bf9-4d3f-82d5-3b31c0267a16",
                    UserId = "ff4b2a5c-f027-4ae4-a1e8-76ed3ca395c2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "281da1c5-74b7-47a3-b8cd-2e19f0b9c4f0",
                    UserId = "52902de6-aeb7-4df5-86e3-26e203b6ccc5"
                }
            );
        }
    }
}
