using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
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
using System.Xml.Linq;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class Delete_LeaveTypeCommandHandler : IRequestHandler<Delete_LeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public Delete_LeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Delete_LeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveType = await _leaveTypeRepository.GetAsync(request.Id);

            if (leaveType == null)
            {
                response.Success = false;
                response.Message = "Record was not found.";
                return response;
            }

            await _leaveTypeRepository.DeleteAsync(leaveType);

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "Record deleted.";

            return response;
        }
    }
}
