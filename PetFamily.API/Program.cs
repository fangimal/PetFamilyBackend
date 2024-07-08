using Microsoft.EntityFrameworkCore;
using PetFamily.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<PetFamilyDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PetFamilyDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
