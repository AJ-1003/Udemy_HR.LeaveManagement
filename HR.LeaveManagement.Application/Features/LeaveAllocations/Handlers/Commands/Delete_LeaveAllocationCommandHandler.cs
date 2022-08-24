using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class Delete_LeaveAllocationCommandHandler : IRequestHandler<Delete_LeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public Delete_LeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Delete_LeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var leaveAllocation = await _leaveAllocationRepository.GetAsync(request.Id);

            if (leaveAllocation == null)
            {
                response.Success = false;
                response.Message = "Record was not found";
                return response;
            }

            await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

            response.Id = leaveAllocation.Id;
            response.Success = true;
            response.Message = "Record deleted.";

            return response;
        }
    }
}
