using FluentValidation;
using RentingCarsApi.DTO.PostPut_Dtos;

namespace RentingCarsApi.DTO.Configurations
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Gender)
                .NotEmpty()
                .Must(x => x.ToLower() == "male" || x.ToLower() == "female")
                .WithMessage("Gender must be either 'male' or 'female'.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("Phone number is required.")
               .Length(9).WithMessage("Phone number must be 9 digits long.")
               .Matches("^[0-9]+$").WithMessage("Phone number can only contain digits from 0 to 9.");
            RuleFor(x => x.Pesel)
              .NotEmpty().WithMessage("Pesel is required.")
              .Length(11).WithMessage("Pesel must be 11 digits long.")
              .Matches("^[0-9]+$").WithMessage("Pesel can only contain digits from 0 to 9.");
            RuleFor(x => x.IdNumber)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30).WithMessage("IdNumber can have only 30 characters");
        }
    }
}
