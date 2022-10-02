using Application.Extensions.ServiceRegistirations;
using MediatR;
using Persistence.Extensions.ServiceRegistrations;
using System.Reflection;
using Infrastructure.CrossCuttingConcerns.Exceptions.Middleware;
using Serilog.Sinks.MSSqlServer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices(builder.Configuration);



builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();


app.Run();
