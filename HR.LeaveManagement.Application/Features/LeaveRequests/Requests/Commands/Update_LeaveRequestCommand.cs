using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class Update_LeaveRequestCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Update_LeaveRequestDTO LeaveRequestDTO { get; set; }
        public Update_LeaveRequestApprovalDTO UpdateLeaveRequestApprovalDTO { get; set; }
    }
}
