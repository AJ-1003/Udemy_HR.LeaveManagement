using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using System.Diagnostics;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class Create_LeaveTypeCommandHandler : IRequestHandler<Create_LeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public Create_LeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(Create_LeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Create_LeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Record could not be created.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDTO);

            leaveType = await _leaveTypeRepository.CreateAsync(leaveType);

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "Record created.";

            return response;
        }
    }
}
