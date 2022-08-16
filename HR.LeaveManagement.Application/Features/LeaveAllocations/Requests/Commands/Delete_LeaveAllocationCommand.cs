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
    public class Delete_LeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public Delete_LeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}
