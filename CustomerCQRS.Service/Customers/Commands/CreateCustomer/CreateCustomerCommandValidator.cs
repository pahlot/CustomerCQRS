using CustomerCQRS.Core.Common;
using CustomerCQRS.Core.Extensions;
using FluentValidation;
using System;

namespace CustomerCQRS.Infrastructure.Customers.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        // TODO: This could be made configurable
        private const int MAX_AGE = 100;

        public CreateCustomerCommandValidator(IDateTime dateTime)
        {

            RuleFor(v => v.FirstName)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.LastName)
               .MaximumLength(200)
               .NotEmpty();

            RuleFor(v => v.DateOfBirth)
               .Cascade(CascadeMode.Stop).NotEmpty()
               .Must(date => date != default(DateTime))
               .NotEmpty();

            RuleFor(v => v.DateOfBirth)
              .Cascade(CascadeMode.Stop)
              .Must(age => age.GetAge(dateTime) < MAX_AGE)
              .WithMessage($"Cannot be older than {MAX_AGE}");

            RuleFor(v => v.DateOfBirth)
              .Cascade(CascadeMode.Stop)
              .Must(date => date <= dateTime.Now)
              .WithMessage($"Date of birth cannot be in the future");
        }
    }
}
