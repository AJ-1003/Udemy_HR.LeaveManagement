using HR.LeaveManagement.MVC.Models.LeaveAllocations;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveAllocationService
    {
        Task<Response<Guid>> CreateAsync(Guid leaveTypeId);
    }
}
