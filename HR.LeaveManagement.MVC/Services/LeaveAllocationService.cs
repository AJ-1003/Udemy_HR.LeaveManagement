using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveAllocations;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        private readonly IMapper _mapper;

        public LeaveAllocationService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage) : base(localStorage, httpClient)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateAsync(Guid leaveTypeId)
        {
            try
            {
                var response = new Response<Guid>();
                var createLeaveAllocation = new Create_LeaveAllocationDTO()
                {
                    LeaveTypeId = leaveTypeId
                };
                AddBearedToken();
                var apiResponse = await _client.LeaveAllocationsPOSTAsync(createLeaveAllocation);
                if (apiResponse.Success)
                {
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
    }
}
