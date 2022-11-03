using Introspection.Back.Hexagon.Gateways.Repositories;
using Introspection.Back.Infrastructure.Repositories.Dapper;
using Introspection.Back.Infrastructure.Repositories.EF;
using Introspection.Domain.Gateways.Repositories;
using Introspection.Infrastructure.Repositories.InMemory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddSingleton<IntrospectionDapperDbContext>();
builder.Services.AddDbContext<IntrospectionEFDbContext>(options =>
    options.UseSqlite("Filename=database.db"));

// Repositories
builder.Services.AddSingleton<IDayWillReadRepository, DapperDayWillReadRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();