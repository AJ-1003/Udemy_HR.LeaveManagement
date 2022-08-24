using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveTypes;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage) : base(localStorage, httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<Response<Guid>> CreateAsync(Create_LeaveTypeVM newLeaveType)
        {
            AddBearedToken();
            try
            {
                var response = new Response<Guid>();
                var leaveType = _mapper.Map<Create_LeaveTypeDTO>(newLeaveType);
                var apiResponse = await _client.LeaveTypesPOSTAsync(leaveType);
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

        public async Task<LeaveTypeVM> GetAsync(Guid id)
        {
            AddBearedToken();
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetAllAsync()
        {
            AddBearedToken();
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<Guid>> UpdateAsync(Guid id, LeaveTypeVM updatedLeaveType)
        {
            AddBearedToken();
            try
            {
                var leaveType = _mapper.Map<LeaveTypeDTO>(updatedLeaveType);
                await _client.LeaveTypesPUTAsync(id, leaveType);
                return new Response<Guid>()
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteAsync(Guid id)
        {
            AddBearedToken();
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<Guid>()
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
