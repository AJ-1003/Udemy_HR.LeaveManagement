using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class Update_LeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
