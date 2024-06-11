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
            RuleFor(e => e.FirstName)
              .NotEmpty()
              .WithMessage("First name is required.")
              .MinimumLength(3)
              .WithMessage("First name must have at least 3 characters.")
              .MaximumLength(255)
              .WithMessage("First name must have a maximum of 255 characters.");


            RuleFor(e => e.LastName)
              .NotEmpty()
              .WithMessage("Last name is required.")
              .MinimumLength(3)
              .WithMessage("Last name must have at least 3 characters.")
              .MaximumLength(255)
              .WithMessage("Last name must have a maximum of 255 characters.");

            RuleFor(e => e.Document)
              .NotEmpty()
              .WithMessage("Document is required.")
              .Length(11)
              .WithMessage("Document must have 11 characters.");

            RuleFor(e => e.Sector)
              .NotEmpty()
              .WithMessage("Sector is required.")
              .MinimumLength(2)
              .WithMessage("Sector must have at least 3 characters.")
              .MaximumLength(255)
              .WithMessage("Sector must have a maximum of 255 characters.");

            RuleFor(e => e.GrossSalary)
                .GreaterThan(0)
                .WithMessage("Gross Salary must be greater than R$ 0,00")
                .LessThan(decimal.MaxValue)
                .WithMessage("Gross Salary must be less than " + decimal.MaxValue.ToString("C2"));

            RuleFor(e => e.AdmissionDate)
                .NotEmpty()
                .WithMessage("Addmision date is required")
                .LessThan(new DateTime(DateTime.Now.Year, 12, 31))
                .WithMessage("Admission date connot be greather than the current year");
        }
    }
}
