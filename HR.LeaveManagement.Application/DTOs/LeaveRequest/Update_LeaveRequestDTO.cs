using HR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class Update_LeaveRequestDTO : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
        public bool Cancelled { get; set; }
    }
}
