using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveAllocations;
using HR.LeaveManagement.MVC.Models.LeaveRequests;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public LeaveRequestService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage) : base(localStorage, httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task ApproveLeaveRequest(Guid id, bool approved)
        {
            AddBearedToken();
            try
            {
                var request = new Update_LeaveRequestApprovalDTO { Approved = approved, Id = id };
                await _client.ChangeApprovalAsync(id, request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Guid>> CreateAsync(Create_LeaveRequestVM leaveRequest)
        {
            try
            {
                var response = new Response<Guid>();
                var createLeaveRequest = _mapper.Map<Create_LeaveRequestDTO>(leaveRequest);
                AddBearedToken();
                var apiResponse = await _client.LeaveRequestsPOSTAsync(createLeaveRequest);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public Task DeleteLeaveRequest(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            AddBearedToken();
            var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: false);

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };
            return model;
        }

        public async Task<LeaveRequestVM> GetAsync(Guid id)
        {
            AddBearedToken();
            var leaveRequest = await _client.LeaveRequestsGETAsync(id);
            return _mapper.Map<LeaveRequestVM>(leaveRequest);
        }

        public async Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests()
        {
            AddBearedToken();
            var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: true);
            var allocations = await _client.LeaveAllocationsAllAsync(isLoggedInUser: true);
            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            return model;
        }
    }
}
