﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class Create_LeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public Create_LeaveRequestDTO LeaveRequestDTO { get; internal set; }
    }
}
