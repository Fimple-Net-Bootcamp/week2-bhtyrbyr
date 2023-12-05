using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.Concrete;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;
using UniversalWeahterForecast.DataAccessLayer.EntityFramework;
using UniversalWeahterForecast.EntityLayer.Entitys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UniversalWeatherForecastDbContext>(options => options.UseInMemoryDatabase(databaseName: "UniversalWeatherForecastDB"));
builder.Services.AddScoped<IUniversalWeatherForecastDbContext>(provider => provider.GetRequiredService<UniversalWeatherForecastDbContext>());

builder.Services.AddScoped<ICelestalBodyDal, EfCelestalBodyDal>();
builder.Services.AddScoped<ICelestalBodyService, CelestalBodyManager>();

builder.Services.AddScoped<IWeatherForecastDal, EfWeatherForecastDal>();
builder.Services.AddScoped<IWeatherForecastService<WeatherForecast>, WeatherForecastManager>();

builder.Services.AddScoped<IWeatherTypeDal, EfWeatherTypeDal>();
builder.Services.AddScoped<IWeatherTypeService, WeatherTypeManager>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateAsyncScope())
{
    var service = scope.ServiceProvider;
    DataGenerator.Initialize(service); 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
