using FluentValidation;
using FluentValidationSample.Services;

namespace FluentValidationSample.Validation;

public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
{
	public WeatherForecastValidator(IWeatherForecastsService weatherForecastsService)
	{
        RuleFor(x => x.Name)
        .Must(password => weatherForecastsService.IsValidName(password))
        .WithMessage("Sorry password didn't satisfy the custom logic");
    }
}
