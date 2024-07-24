using FluentValidation;
using PetFamily.API.Middlewares;
using PetFamily.Application;
using PetFamily.Application.Abstractions;
using PetFamily.Infrastructure;
using PetFamily.Infrastructure.Repositories;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using DependencyRegistration = PetFamily.API.Validation.DependencyRegistration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddScoped<IPetsRepository, PetRepository>();

builder.Services.AddScoped<PetFamilyDbContext>();

builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.OverrideDefaultResultFactoryWith<DependencyRegistration.CustomResultFactory>();
});

builder.Services.AddHttpLogging(options =>{});
var app = builder.Build();

app.UseMiddleware<ExeptionMiddleware>();
app.UseHttpLogging();

//app.UseExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

 app.Run();
