
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Web.Api;
using Web.Api.Extensions;
using Application;
using Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//en este caso se lo pego directo al services, no al builder
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}



//app.UseExceptionHandler();

//app.UseAuthentication();

//app.UseAuthorization();

// REMARK: If you want to use Controllers, you'll need this.
//app.MapControllers();

await app.RunAsync();


public partial class Program;
