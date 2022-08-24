using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class Update_LeaveAllocationCommandHandler : IRequestHandler<Update_LeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public Update_LeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Update_LeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Update_LeaveAllocationDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Record could not be updated.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveAllocation = await _leaveAllocationRepository.GetAsync(request.LeaveAllocationDTO.Id);

            if (leaveAllocation == null)
            {
                response.Success = false;
                response.Message = "Record was not found.";
                return response;
            }

            _mapper.Map(request.LeaveAllocationDTO, leaveAllocation);

            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);

            response.Id = leaveAllocation.Id;
            response.Success = true;
            response.Message = "Record updated.";

            return response;
        }
    }
}
