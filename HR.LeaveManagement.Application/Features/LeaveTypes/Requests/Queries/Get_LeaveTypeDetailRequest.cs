using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class Get_LeaveTypeDetailRequest : IRequest<LeaveTypeDTO>
    {
        public Guid Id { get; set; }
    }
}
