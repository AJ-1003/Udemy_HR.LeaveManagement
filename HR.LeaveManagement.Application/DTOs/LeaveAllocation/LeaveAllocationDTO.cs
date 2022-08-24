using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Models.Identity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDTO : BaseDTO
    {
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public int NumberOfDays { get; set; } = 1;
        public LeaveTypeDTO LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Period { get; set; } = 2022;
    }
}
