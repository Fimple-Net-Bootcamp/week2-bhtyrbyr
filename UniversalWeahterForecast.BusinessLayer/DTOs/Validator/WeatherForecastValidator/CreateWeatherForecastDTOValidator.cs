using FluentValidation;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.Validator.WeatherForecastValidator
{
    internal class CreateWeatherForecastDTOValidator : AbstractValidator<CreateWeatherForecastDTO>
    {
        public CreateWeatherForecastDTOValidator()
        {
            RuleFor(property => property.WeatherTime).GreaterThan(DateTime.Now).LessThan(DateTime.Now.AddDays(14));
            RuleFor(property => property.BodyId).GreaterThan(0);
            RuleFor(property => property.TypeId).GreaterThan(0);
        }
    }
}
