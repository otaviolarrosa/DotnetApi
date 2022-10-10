using Application.Extensions;
using Consumers;
using Infrastructure.Extensions;
using Producers;
using Serilog;
using StreamNet;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.WithCorrelationId()
    .Enrich.WithCorrelationIdHeader()
    .WriteTo.Console(outputTemplate: "[{CorrelationId} - {Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(builder.Logging);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterApplicationDependencies(builder.Configuration);
builder.Services.RegisterInfrastructureDependencies(builder.Configuration);
builder.Services.AddProducers();
builder.Services.AddConsumers();
builder.Services.AddTopicManagement();

var app = builder.Build();
app.RunMigrations(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
