using FluentValidation;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.Validator.CelestalBodyValidator
{
    internal class CreateCelestalBodyDTOValidator : AbstractValidator<CreateCelestalBodyDTO>
    {
        public CreateCelestalBodyDTOValidator()
        {
            RuleFor(property => property.Name).NotEmpty().NotNull().Must(value => value != "string");
            RuleFor(property => property.CelestalBodyType).Must(value => value == "planet" || value == "satellite");
        }
    }
}
