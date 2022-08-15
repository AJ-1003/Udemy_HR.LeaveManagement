using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class Update_LeaveRequestCommandHandler : IRequestHandler<Update_LeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public Update_LeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Update_LeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetAsync(request.Id);

            if (request.LeaveRequestDTO != null)
            {
                _mapper.Map(request.LeaveRequestDTO, leaveRequest);

                await _leaveRequestRepository.UpdateAsync(leaveRequest);
            }
            else
            {
                await _leaveRequestRepository.UpdateApprovalStatus(leaveRequest, request.UpdateLeaveRequestApprovalDTO.Approved);
            }

            return Unit.Value;
        }
    }
}
