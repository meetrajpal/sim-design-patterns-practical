namespace Practical26.BAL.Validators.Departments;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().Must(x => Guid.TryParse(x, out _)).WithMessage("Id must be a valid GUID.");
    }
}
