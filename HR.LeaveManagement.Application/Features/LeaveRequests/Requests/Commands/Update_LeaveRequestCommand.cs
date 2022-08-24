using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class Update_LeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
        public Update_LeaveRequestDTO UpdateLeaveRequestDTO { get; set; }
        public Update_LeaveRequestApprovalDTO UpdateLeaveRequestApprovalDTO { get; set; }
    }
}
