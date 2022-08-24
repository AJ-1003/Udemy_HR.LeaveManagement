using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class Create_LeaveAllocationDTO/* : ILeaveAllocationDTO*/
    {
        public Guid LeaveTypeId { get; set; }
        //public int NumberOfDays { get; set; } = 1;
        //public int Period { get; set; } = 2022;
    }
}
