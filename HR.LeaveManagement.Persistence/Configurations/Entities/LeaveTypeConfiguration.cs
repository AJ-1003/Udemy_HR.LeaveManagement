using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = Guid.NewGuid(),
                    DefaultDays = 10,
                    Name = "Annual"
                },
                new LeaveType
                {
                    Id = Guid.NewGuid(),
                    DefaultDays = 32,
                    Name = "Sick"
                }
            );
        }
    }
}
