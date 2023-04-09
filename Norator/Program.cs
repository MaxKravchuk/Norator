using Application.Configuration;
using DataAccess.Context;
using DataAccess.Repositories.Configuration;
using WebApi.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Norator.Middleware;
using Norator.Configuration;
using Microsoft.Extensions.Logging;
using log4net.Config;
using log4net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NoratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddApplicationRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddApplicationMappers();
builder.Services.AddSystemServices();

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


var app = builder.Build();

app.AddApplicationMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Norator");

app.UseAuthorization();

app.MapControllers();

app.Run();
