using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Domain;
using FluentValidation;
using ValidationException = HR.LeaveManagement.Application.Exceptions.ValidationException;
using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class Update_LeaveRequestCommandHandler : IRequestHandler<Update_LeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public Update_LeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Update_LeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Update_LeaveRequestDTOValidator(_leaveTypeRepository);
            ValidationResult validationResult = new ValidationResult();


            if (request.UpdateLeaveRequestDTO != null)
            {
                validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDTO);
            }

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Record could not be updated.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveRequest = await _leaveRequestRepository.GetAsync(request.Id);

            leaveRequest.DateRequested = leaveRequest.DateRequested;

            if (leaveRequest == null)
            {
                response.Success = false;
                response.Message = "Record was not found.";
                return response;
            }

            if (request.UpdateLeaveRequestDTO != null)
            {
                _mapper.Map(request.UpdateLeaveRequestDTO, leaveRequest);

                if (request.UpdateLeaveRequestDTO.Cancelled != false || request.UpdateLeaveRequestDTO.Cancelled != null)
                {
                    leaveRequest.DateActioned = DateTime.Now;
                }

                await _leaveRequestRepository.UpdateAsync(leaveRequest);
            }
            else if (request.UpdateLeaveRequestApprovalDTO != null)
            {
                if (request.UpdateLeaveRequestApprovalDTO.Approved != false || request.UpdateLeaveRequestApprovalDTO.Approved != null)
                {
                    leaveRequest.DateActioned = DateTime.Now;
                }
                await _leaveRequestRepository.UpdateApprovalStatus(leaveRequest, request.UpdateLeaveRequestApprovalDTO.Approved);
            }

            response.Id = leaveRequest.Id;
            response.Success = true;
            response.Message = "Record updated.";

            return response;
        }
    }
}
