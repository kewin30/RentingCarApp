using FluentValidation;
using RentingCarsApi.DTO.GetDtos;
using System.Text.RegularExpressions;

namespace RentingCarsApi.DTO.Configurations
{
    public class CarDtoValidator : AbstractValidator<CarDto>
    {
        public CarDtoValidator()
        {
            //RuleFor(x => x.Vin)
            //    .NotEmpty().WithMessage("Vin is required.");

            //RuleFor(x => x.GpsEnabled)
            //    .NotNull().WithMessage("GpsEnabled is required.")
            //    .Must(x => x == true || x == false).WithMessage("GpsEnabled must be either true or false.");

            //RuleFor(x => x.Plate)
            //    .NotEmpty().WithMessage("Plate is required.")
            //    .MaximumLength(20).WithMessage("Plate must not exceed 20 characters.");

            //RuleFor(x => x.Model)
            //    .NotEmpty().WithMessage("Model is required.");

            //RuleFor(x => x.CarYear)
            //    .NotEmpty().WithMessage("CarYear is required.")
            //    .Must(x => Regex.IsMatch(x.ToString(), @"^[0-9]+$")).WithMessage("CarYear must be a numeric value.");

            //RuleFor(x => x.Color)
            //    .NotEmpty().WithMessage("Color is required.");

            //RuleFor(x => x.Weight)
            //    .NotEmpty().WithMessage("Weight is required.")
            //    .Must(x => Regex.IsMatch(x.ToString(), @"^[0-9]+$")).WithMessage("Weight must be a numeric value.");

            //RuleFor(x => x.PrizeForDay)
            //    .NotEmpty().WithMessage("PrizeForDay is required.")
            //    .Must(x => Regex.IsMatch(x.ToString(), @"^[0-9]+$")).WithMessage("PrizeForDay must be a numeric value.");

            //RuleFor(x => x.PrizeForWeek)
            //    .NotEmpty().WithMessage("PrizeForWeek is required.")
            //    .Must(x => Regex.IsMatch(x.ToString(), @"^[0-9]+$")).WithMessage("PrizeForWeek must be a numeric value.");

            //RuleFor(x => x.Place)
            //    .NotEmpty().WithMessage("Place is required.")
            //    .Must(x => x.ToLower() == "palma airport" || x.ToLower() == "palma city center" || x.ToLower() == "alcudia" || x.ToLower() == "manacor")
            //    .WithMessage("Invalid value for Place. Available: Palma Airport, Palma City Center, Alcudia, Manacor");
        }
    }
}
