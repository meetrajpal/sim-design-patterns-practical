namespace Practical26.BAL.Validators.Departments;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.DepartmentName).NotNull().NotEmpty().WithMessage("DepartmentName is required.");
    }
}
