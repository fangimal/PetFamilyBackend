﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Features.Volunteer.CreatePet;
using PetFamily.Application.Features.Volunteer.CreateVolunteer;
using PetFamily.Application.Features.Volunteer.DeletePhoto;
using PetFamily.Application.Features.Volunteer.UploadPhoto;

namespace PetFamily.Application;

public static class DependencyRegistration
{
    public static IServiceCollection  AddApplication(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<CreatePetHandler>();
        services.AddScoped<CreateVolunteerHandler>();
        services.AddScoped<UploadVolunteerPhotoHandler>();
        services.AddScoped<DeleteVolunteerPhotoHandler>();
        return services;
    }
}