﻿using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class Create_LeaveAllocationCommand : IRequest<Guid>
    {
        public Create_LeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}
