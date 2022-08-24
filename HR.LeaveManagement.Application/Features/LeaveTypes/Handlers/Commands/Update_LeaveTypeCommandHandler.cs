using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class Update_LeaveTypeCommandHandler : IRequestHandler<Update_LeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public Update_LeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(Update_LeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Update_LeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Record could not be updated.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveType = await _leaveTypeRepository.GetAsync(request.LeaveTypeDTO.Id);

            if (leaveType == null)
            {
                response.Success = false;
                response.Message = "Record was not found.";
                return response;
            }

            _mapper.Map(request.LeaveTypeDTO, leaveType);

            await _leaveTypeRepository.UpdateAsync(leaveType);

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "Record updated.";

            return response;
        }
    }
}
