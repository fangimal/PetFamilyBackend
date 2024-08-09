using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using PetFamily.Application.Features.Pets;
using PetFamily.Application.Features.Volunteer;
using PetFamily.Infrastructure.DbContexts;
using PetFamily.Infrastructure.Options;
using PetFamily.Infrastructure.Queries.Pets;
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
            .AddQueries();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPetsRepository, PetsRepository>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        
        return services;
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<GetPetsQuery>();
        services.AddScoped<GetAllPetsQuery>();
        return services;
    }

    private static IServiceCollection AddDataStorages(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<PetFamilyWriteDbContext>();
        services.AddScoped<PetFamilyReadDbContext>();
        services.AddSingleton<SqlConnectionFactory>();

        services.AddMinio(options =>
        {
            var minioOptionns = configuration.GetSection(MinioOptions.Minio)
                .Get<MinioOptions>() ?? throw new Exception("Minio configuration not found");
            
            options.WithEndpoint(minioOptionns.Endpoint);
            options.WithSSL(false);
            options.WithCredentials(minioOptionns.AccessKey, minioOptionns.SecretKey);
        });
        return services;
    }
}