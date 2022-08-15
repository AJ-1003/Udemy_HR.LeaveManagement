﻿using HR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType
{
    public class Delete_LeaveTypeDTO : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
