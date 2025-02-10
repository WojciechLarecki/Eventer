using Eventer.API;
using Eventer.API.Logging;
using Eventer.Data.Repositories;
using Eventer.Logic.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
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
app.UseCors(MyAllowSpecificOrigins);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
