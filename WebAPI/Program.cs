using Application.Extensions.ServiceRegistirations;
using Persistence.Extensions.ServiceRegistrations;
using Infrastructure.CrossCuttingConcerns.Exceptions.Middleware;
using Infrastructure.DependencyResolvers;
using Infrastructure.Extensions;
using Infrastructure.Utilities.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});


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
