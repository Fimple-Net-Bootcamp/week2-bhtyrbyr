using FluentValidation;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.Validator.CelestalBodyValidator
{
    internal class UpdateCelestalBodyDTOValidator : AbstractValidator<UpdateCelestalBodyDTO>
    {
        public UpdateCelestalBodyDTOValidator()
        {
            RuleFor(property => property.Name).NotEmpty().NotNull().Must(value => value != "string");
            RuleFor(property => property.CelestalBodyType).Must(value => value == "planet" || value == "satellite");
        }
    }
}
