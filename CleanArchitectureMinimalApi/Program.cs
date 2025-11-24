using System.Reflection;
using Infrastructure;
using Application;
using CleanArchitectureMinimalApi;
using CleanArchitectureMinimalApi.Extensions;
using Asp.Versioning.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

#region versioning, después del dependencyInjection
ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new Asp.Versioning.ApiVersion(1))
    .HasApiVersion(new Asp.Versioning.ApiVersion(2))
    .ReportApiVersions()
    .Build();

RouteGroupBuilder versionGroup = app.
    MapGroup("api/v{apiVersion:apiVersion}")
    .WithApiVersionSet(apiVersionSet);
//vamos a los endpoints para configurar cual versión va a utilizar cada uno
#endregion
//MapEndpoints ya venía con ello en caso de necesitarlo
app.MapEndpoints(versionGroup);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
    app.MapOpenApi();
}
 

app.UseHttpsRedirection();


app.Run();

