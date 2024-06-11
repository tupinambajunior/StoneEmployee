using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StoneEmployee.Core.Entities;

namespace StoneEmployee.Core.Validator
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(user => user.FirstName)
              .NotEmpty()
              .WithMessage("First name is required.")
              .MinimumLength(3)
              .WithMessage("First name must have at least 3 characters.")
              .MaximumLength(255)
              .WithMessage("First name must have a maximum of 255 characters.");

           
        }
    }
}
