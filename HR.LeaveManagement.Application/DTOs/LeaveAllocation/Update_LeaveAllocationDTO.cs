using HR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class Update_LeaveAllocationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
