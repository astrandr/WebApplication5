using FluentValidation;
using WebApplication5.Models;

namespace WebApplication5.Validators
{
    public class UpdateDepartmentEmployeeRequestValidator : AbstractValidator<UpdateDepartmentEmployeeRequest>
    {
        public UpdateDepartmentEmployeeRequestValidator()
        {
            RuleFor(x => x.Employee)
                .MaximumLength(25).WithMessage("Employee name must be at most 25 characters.")
                .When(x => x.Employee != null);

            RuleFor(x => x.Department)
                .MaximumLength(25).WithMessage("Department must be at most 25 characters.")
                .When(x => x.Department != null);

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary must be >= 0.")
                .When(x => x.Salary.HasValue);
        }
    }
}
