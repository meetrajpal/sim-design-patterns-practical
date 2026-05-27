namespace Practical26.BAL.Validators.Employees;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().Must(x => Guid.TryParse(x, out _)).WithMessage("Id must be a valid GUID.");
    }
}
