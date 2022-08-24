using HR.LeaveManagement.MVC.Models.LeaveTypes;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetAllAsync();
        Task<LeaveTypeVM> GetAsync(Guid id);
        Task<Response<Guid>> CreateAsync(Create_LeaveTypeVM newLeaveType);
        Task<Response<Guid>> UpdateAsync(Guid id, LeaveTypeVM updatedLeaveType);
        Task<Response<Guid>> DeleteAsync(Guid id);
    }
}
