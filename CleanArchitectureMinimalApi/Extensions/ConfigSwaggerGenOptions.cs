using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CleanArchitectureMinimalApi.Extensions
{
    /// <summary>
    /// <remarks>
    /// IConfigureNamedOptions es principalmente como el extensor que me permite indicar a quien le voy a extender los configuraciones
    /// </remarks>
    /// </summary>
    public class ConfigSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;


        public ConfigSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                //este me define la parte visual y que reconozca la parte de los endpoints
                var openApiInfo = new OpenApiInfo
                {
                    Title = $"Versioning.API v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = "Minimal API",
                    Contact = new OpenApiContact
                    {
                        Name = "GROUP S.A",
                        Email = "change.me",
                        Url = new Uri("https://localhost.com/"),
                    }
                };
                options.SwaggerDoc(description.GroupName, openApiInfo);
            }
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        }
    }
}
