using Eventer.API;
using Eventer.Data.Repositories;
using Eventer.Logic.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlConnection(builder.Configuration.GetConnectionString("Eventer"));
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
