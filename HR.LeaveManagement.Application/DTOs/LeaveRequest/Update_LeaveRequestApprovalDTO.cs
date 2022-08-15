using HR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class Update_LeaveRequestApprovalDTO : BaseDTO
    {
        public bool? Approved { get; set; }
    }
}
