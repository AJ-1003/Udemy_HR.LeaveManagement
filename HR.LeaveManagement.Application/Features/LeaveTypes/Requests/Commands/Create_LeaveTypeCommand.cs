﻿using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class Create_LeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public Create_LeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
