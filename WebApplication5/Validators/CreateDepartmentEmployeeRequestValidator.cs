using FluentValidation;
using WebApplication5.Models;

namespace WebApplication5.Validators
{
    public class CreateDepartmentEmployeeRequestValidator : AbstractValidator<CreateDepartmentEmployeeRequest>
    {
        public CreateDepartmentEmployeeRequestValidator()
        {
            RuleFor(x => x.Employee)
                .NotEmpty().WithMessage("Employee name is required.")
                .MaximumLength(25).WithMessage("Employee name must be at most 25 characters.");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department is required.")
                .MaximumLength(25).WithMessage("Department must be at most 25 characters.");

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary must be >= 0.")
                .When(x => x.Salary.HasValue);
        }
    }
}
