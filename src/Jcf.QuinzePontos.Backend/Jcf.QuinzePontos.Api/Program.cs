using Jcf.QuinzePontos.Api.Configurations;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Jcf.QuinzePontos.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetSection("EnvironmentName").Value);

bool isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddDatabaseConfiguration(builder.Configuration, isDevelopment);
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (isDevelopment)
{
    app.MapOpenApi("v1");
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
