using Jcf.QuinzePontos.Application.DependencyInjection;
using Jcf.QuinzePontos.GetResultsWorker;
using Jcf.QuinzePontos.Infrastructure.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

Console.WriteLine(builder.Configuration.GetSection("EnvironmentName").Value);

builder.Services.AddApplicationServices();
builder.Services.AddDatabaseConfiguration(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddCustomRepositories();
builder.Services.AddHostedService<LotoFacilWorker>();

var host = builder.Build();
host.Run();
