using FluentValidation;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.Validator.WeatherForecastValidator
{
    internal class UpdateWeatherForecastDTOValidator : AbstractValidator<UpdateWeatherForecastDTO>
    {
        public UpdateWeatherForecastDTOValidator()
        {
            RuleFor(command => command.BodyId).GreaterThan(0);
            RuleFor(command => command.TypeId).GreaterThan(0);
        }
    }
}
