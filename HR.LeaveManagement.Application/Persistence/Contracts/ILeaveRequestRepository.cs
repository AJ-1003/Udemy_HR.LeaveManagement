﻿using HR.LeaveManagement.Application.Persistence.Contracts.Common;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        Task UpdateApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}