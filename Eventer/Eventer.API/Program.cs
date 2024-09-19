using Eventer.API;
using Eventer.API.Logging;
using Eventer.Data.Repositories;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// disable automatic http 400 response if model given to endpoint is invalid
builder.Services.Configure<ApiBehaviorOptions>(options => 
{
    options.SuppressModelStateInvalidFilter = true; 
});

// Add services to the container.
builder.Services.AddSqlConnection(builder.Configuration.GetConnectionString("Eventer"));
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<EventService>();
builder.Services.AddTransient<FileService>();
builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();
builder.Services.AddTransient(typeof(IRequestLogger<>), typeof(RequestLogger<>));
builder.Services.AddControllers();

// use logging library instead of default microsoft logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
