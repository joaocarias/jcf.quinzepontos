using Jcf.QuinzePontos.Application.DependencyInjection;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Clients;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Options;
using Jcf.QuinzePontos.GetResultsWorker;
using Jcf.QuinzePontos.Infrastructure.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

Console.WriteLine(builder.Configuration.GetSection("EnvironmentName").Value);

builder.Services
    .AddOptions<LotofacilApiOptions>()
    .Bind(builder.Configuration.GetSection("APIs:LotofacilGetResultado"))
    .ValidateOnStart(); ;

builder.Services.AddApplicationServices();
builder.Services.AddApplicationHttpsClients();
builder.Services.AddDatabaseConfiguration(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddRepositories();
builder.Services.AddHostedService<LotoFacilWorker>();
    
var host = builder.Build();
host.Run();
