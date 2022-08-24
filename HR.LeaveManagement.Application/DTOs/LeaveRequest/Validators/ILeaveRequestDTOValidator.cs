using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDTOValidator : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(lr => lr.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now)
                .LessThan(lr => lr.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(lr => lr.EndDate)
                .GreaterThan(lr => lr.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(lr => lr.LeaveTypeId)
                .NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist!");
        }
    }
}
