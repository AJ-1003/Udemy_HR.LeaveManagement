using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class Create_LeaveRequestCommandHandler : IRequestHandler<Create_LeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public Create_LeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository,
            IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Create_LeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Create_LeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(uid => uid.Type == "uid")?.Value;
            var allocation = await _leaveAllocationRepository.GetUserAllocations(userId, request.LeaveRequestDTO.LeaveTypeId);
            int daysRequested = (int)(request.LeaveRequestDTO.EndDate - request.LeaveRequestDTO.StartDate).TotalDays;

            if (daysRequested > allocation.NumberOfDays)
            {
                validationResult.Errors
                    .Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveRequestDTO.EndDate), "You do not have enough days for this request"));
            }

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = response.Message = "Record could not be created.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            else
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);

                leaveRequest.StartDate = DateTime.UtcNow;
                leaveRequest.DateRequested = DateTime.UtcNow;
                leaveRequest.RequestingEmployeeId = userId;

                leaveRequest = await _leaveRequestRepository.CreateAsync(leaveRequest);

                response.Id = leaveRequest.Id;
                response.Success = true;
                response.Message = "Record created.";

                try
                {
                    var emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;

                    var email = new Email
                    {
                        To = emailAddress,
                        Subject = $"Your leave request for {request.LeaveRequestDTO.StartDate:D} to {request.LeaveRequestDTO.EndDate:D} has been submitted successfully",
                        Body = "Leave request submitted"
                    };

                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = $"Email not sent due to {ex.Message}";
                }
            }

            return response;
        }
    }
}
