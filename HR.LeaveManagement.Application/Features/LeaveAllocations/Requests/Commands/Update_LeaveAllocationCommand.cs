﻿using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class Update_LeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
        public Update_LeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}
