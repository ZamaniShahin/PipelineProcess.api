﻿using System.Reflection;
using Ardalis.ListStartupServices;
using Ardalis.SharedKernel;
using Tracking.api.Core.Interfaces;
using Tracking.api.Infrastructure;
using Tracking.api.Infrastructure.Data;
using Tracking.api.Infrastructure.Email;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Tracking.api.UseCases.Services.Schemas.Commands;
using Tracking.api.Web.Seeds;
using Serilog;
using Serilog.Extensions.Logging;

var appLogger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

appLogger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(appLogger)
  .CreateLogger<Program>();

// Configure Web Behavior
builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddFastEndpoints()
  .SwaggerDocument(o =>
  {
    o.ShortSchemaNames = true;
  });

ConfigureMediatR();

builder.Services.AddInfrastructureServices(builder.Configuration, microsoftLogger);

if (builder.Environment.IsDevelopment())
{
  // Use a local test email server
  // See: https://ardalis.com/configuring-a-local-test-email-server/
  builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();

  // Otherwise use this:
  //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();
  AddShowAllServicesSupport();
}
else
{
  builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
  app.UseDefaultExceptionHandler(); // from FastEndpoints
  app.UseHsts();
}

app.UseFastEndpoints()
  .UseSwaggerGen(); // Includes AddFileServer and static files middleware

app.UseHttpsRedirection();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
  var context = services.GetRequiredService<AppDbContext>();
  context.Database.Migrate();
  context.Database.EnsureCreated();
  await SeedFactories.InitializeAsync(services);
}
catch (Exception ex)
{
  var logger = services.GetRequiredService<ILogger<Program>>();
  logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
}

app.Run();





void ConfigureMediatR()
{
  builder.Services.AddMediatR(cfg =>
  {
    // Register handlers from the current assembly or other relevant assemblies
    cfg.RegisterServicesFromAssembly(typeof(CreateSchemaCommand).Assembly); // Adjust as necessary
  });

  // Register other required services
  builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
  builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}

void AddShowAllServicesSupport()
{
  // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
  builder.Services.Configure<ServiceConfig>(config =>
  {
    config.Services = new List<ServiceDescriptor>(builder.Services);

    // optional - default path to view services is /listallservices - recommended to choose your own path
    config.Path = "/listservices";
  });
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
