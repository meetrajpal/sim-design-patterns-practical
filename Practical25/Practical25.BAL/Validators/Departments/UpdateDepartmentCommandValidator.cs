using FluentValidation;
using Practical25.BAL.Commands.Departments;

namespace Practical25.BAL.Validators.Departments;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).Must(id => Guid.TryParse(id, out _)).WithMessage("Id must be a valid GUID.");
        RuleFor(x => x.DepartmentName).NotNull().NotEmpty().WithMessage("DepartmentName cannot be empty string.").When(x => x.DepartmentName != null);
    }
}
