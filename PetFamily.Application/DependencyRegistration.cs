﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Pets.CreatePet;

namespace PetFamily.Application;

public static class DependencyRegistration
{
    public static IServiceCollection  AddApplication(this IServiceCollection services)
    {
        services.AddServices();
        services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<CreatePetService>();
        services.AddScoped<CreatePetService>();
        return services;
    }
}