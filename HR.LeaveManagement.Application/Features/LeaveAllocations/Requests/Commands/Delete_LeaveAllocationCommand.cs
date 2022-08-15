﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class Delete_LeaveAllocationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
