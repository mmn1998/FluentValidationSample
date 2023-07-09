namespace FluentValidationSample.Services;

public interface IWeatherForecastsService
{
    public bool IsValidName(string name);
}
public class WeatherForecastsService : IWeatherForecastsService
{
    public bool IsValidName(string name)
    {
        if(name != "mehdi")
            throw new Exception("name is not valid");
        else return true;
    }
}
