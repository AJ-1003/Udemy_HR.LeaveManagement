using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType
{
    public class Create_LeaveTypeDTO : ILeaveTypeDTO
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; } = 1;
    }
}
