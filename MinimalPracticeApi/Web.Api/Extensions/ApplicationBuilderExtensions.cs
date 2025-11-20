using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Web.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelsExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MC_CiudadMunicipal_Backend API V1.0.0");
        });

        return app;
    }
}
