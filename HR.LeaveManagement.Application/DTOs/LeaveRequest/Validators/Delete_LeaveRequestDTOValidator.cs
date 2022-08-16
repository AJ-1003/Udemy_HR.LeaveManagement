using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class Delete_LeaveRequestDTOValidator : AbstractValidator<Delete_LeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public Delete_LeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDTOValidator(_leaveTypeRepository));

            RuleFor(lr => lr.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
