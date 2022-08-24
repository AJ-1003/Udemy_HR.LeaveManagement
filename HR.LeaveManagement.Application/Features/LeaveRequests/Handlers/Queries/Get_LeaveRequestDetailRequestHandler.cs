using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Identity;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class Get_LeaveRequestDetailRequestHandler : IRequestHandler<Get_LeaveRequestDetailRequest, LeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public Get_LeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IUserService userService, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDTO> Handle(Get_LeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequestDTO>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));
            leaveRequest.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeeId);
            return leaveRequest;
        }
    }
}
