using FluentValidation.Domain.Entities;

namespace FluentValidation.API.Validator
{
    public class BankAccountValidator : AbstractValidator<BankAccount>
    {
        public BankAccountValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty() 
                .WithMessage("First name is empty or null.")
                .Length(0, 10)
                .WithMessage("First name is too long.");

            RuleFor(x => x.LastName)
              .NotNull()
              .NotEmpty()
              .WithMessage("Last name is empty or null.")
              .Length(0, 15)
              .WithMessage("Last name is too long.");
           
            RuleFor(x => x.Balance)
             .GreaterThanOrEqualTo(0)
             .WithMessage("Balance must be greater than or equal to zero.");

        }
    }
}