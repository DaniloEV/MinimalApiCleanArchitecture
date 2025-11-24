using Asp.Versioning.ApiExplorer;

namespace CleanArchitectureMinimalApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //version simple
                //c.DefaultModelsExpandDepth(-1);
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Minimal API V1.0.0");
                //este me define las rutas
                IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

                foreach (var description in descriptions)
                {
                    string url = $"/swagger/{description.GroupName}/swagger.json";
                    string name = description.GroupName.ToUpperInvariant();
                    c.SwaggerEndpoint(url,name);
                }
            });

            return app;
        }
    }

}
