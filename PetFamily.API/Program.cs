using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetFamily.API.Authorization;
using PetFamily.API.Middlewares;
using PetFamily.API.Validation;
using PetFamily.Application;
using PetFamily.Infrastructure;
using PetFamily.Infrastructure.DbContexts;
using PetFamily.Infrastructure.Options;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new()
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new()
    {
        {
            new()
            {
                Reference = new()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});
builder.Services.AddControllers();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

builder.Services.AddHttpLogging(options => { });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>()
                  ?? throw new ApplicationException("Wrong configuration");

        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key.SecretKey));

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = symmetricKey
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionsAuthorizationsHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

// add hangfire client
// builder.Services.AddHangfire(configuration => configuration
//     .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
//     .UseSimpleAssemblyNameTypeSerializer()
//     .UseRecommendedSerializerSettings()
//     .UsePostgreSqlStorage(c => c
//         .UseNpgsqlConnection(builder.Configuration.GetConnectionString("HangFire"))));

// add hangfire server
// builder.Services.AddHangfireServer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<PetFamilyWriteDbContext>();
    await dbContext.Database.MigrateAsync();

    // var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("admin");
    //
    // var admin = new User("admin", passwordHash, Role.Admin);
    //
    // await dbContext.Users.AddAsync(admin);
    // await dbContext.SaveChangesAsync();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// app.UseHangfireDashboard();
// app.MapHangfireDashboard("/dashboard");

app.Run();