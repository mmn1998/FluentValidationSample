using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationSample.Services;
using FluentValidationSample.Validation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IWeatherForecastsService, WeatherForecastsService>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<IValidator<WeatherForecast>, WeatherForecastValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();
app.Run();

public class WeatherForecast
{
    public WeatherForecast(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
