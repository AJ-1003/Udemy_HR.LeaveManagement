using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class Update_LeaveTypeDTOValidator : AbstractValidator<LeaveTypeDTO>
    {
        public Update_LeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDTOValidator());

            RuleFor(lt => lt.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
