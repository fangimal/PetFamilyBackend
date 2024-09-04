﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using PetFamily.Application.DataAccess;
using PetFamily.Application.Features.Accounts;
using PetFamily.Application.Features.Volunteers;
using PetFamily.Application.Providers;
using PetFamily.Infrastructure.DbContexts;
using PetFamily.Infrastructure.Options;
using PetFamily.Infrastructure.Providers;
using PetFamily.Infrastructure.Queries.Pets;
using PetFamily.Infrastructure.Queries.Volunteers.GetVolunteerById;
using PetFamily.Infrastructure.Repositories;

namespace PetFamily.Infrastructure;

public static class DependencyRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataStorages(configuration)
            .AddRepositories()
            .AddQueries()
            .AddProviders();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }

    private static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddScoped<IMinioProvider, MinioProvider>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<GetPetsQuery>();
        services.AddScoped<GetAllPetsQuery>();
        services.AddScoped<GetVolunteerByIdQuery>();

        return services;
    }

    private static IServiceCollection AddDataStorages(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPetFamilyWriteDbContext, PetFamilyWriteDbContext>();
        services.AddScoped<PetFamilyWriteDbContext>();
        services.AddScoped<PetFamilyReadDbContext>();
        services.AddSingleton<SqlConnectionFactory>();

        services.AddMinio(options =>
        {
            var minioOptions = configuration.GetSection(MinioOptions.Minio)
                .Get<MinioOptions>() ?? throw new("Minio configuration not found");

            options.WithEndpoint(minioOptions.Endpoint);
            options.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
            options.WithSSL(false);
        });
        
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));

        return services;
    }
}