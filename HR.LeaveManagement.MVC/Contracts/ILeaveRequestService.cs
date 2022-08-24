using HR.LeaveManagement.MVC.Models.LeaveRequests;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests();
        Task<Response<Guid>> CreateAsync(Create_LeaveRequestVM leaveRequest);
        Task<LeaveRequestVM> GetAsync(Guid id);
        Task DeleteLeaveRequest(Guid id);
        Task ApproveLeaveRequest(Guid id, bool approved);
    }
}
