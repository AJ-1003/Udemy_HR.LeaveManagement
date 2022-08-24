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
using HR.LeaveManagement.Application.Contracts.Identity;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class Create_LeaveAllocationCommandHandler : IRequestHandler<Create_LeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public Create_LeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IUserService userService, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Create_LeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Create_LeaveAllocationDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Record could not be created.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            else
            {
                var leaveType = await _leaveTypeRepository.GetAsync(request.LeaveAllocationDTO.LeaveTypeId);
                var employees = await _userService.GetEmployees();
                var period = DateTime.Now.Year;
                var allocations = new List<LeaveAllocation>();
                foreach (var emp in employees)
                {
                    if (await _leaveAllocationRepository.AllocationExists(emp.Id.ToString(), leaveType.Id, period))
                    {
                        continue;
                    }
                    allocations.Add(new LeaveAllocation
                    {
                        EmployeeId = emp.Id.ToString(),
                        LeaveTypeId = leaveType.Id,
                        NumberOfDays = leaveType.DefaultDays,
                        Period = period
                    });
                }
                await _leaveAllocationRepository.AddAllocations(allocations);

                response.Success = true;
                response.Message = "Allocations successful.";
            }

            //var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDTO);

            //leaveAllocation = await _leaveAllocationRepository.CreateAsync(leaveAllocation);

            //response.Id = leaveAllocation.Id;
            //response.Success = true;
            //response.Message = "Record created.";

            return response;
        }
    }
}
