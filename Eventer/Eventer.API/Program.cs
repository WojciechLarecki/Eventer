using Eventer.API;
using Eventer.API.Logging;
using Eventer.Data.Repositories;
using Eventer.Logic.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlConnection(builder.Configuration.GetConnectionString("Eventer"));
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();
builder.Services.AddTransient(typeof(IRequestLogger<>), typeof(RequestLogger<>));
builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
