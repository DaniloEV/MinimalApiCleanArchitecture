using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArchitectureMinimalApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Demo {groupName}",
                    Version = groupName,
                    Description = "Minimal API",
                    Contact = new OpenApiContact
                    {
                        Name = "GROUP S.A",
                        Email = "change.me",
                        Url = new Uri("https://localhost.com/"),
                    }
                });

                //para este tema hay que hacerle un toque raro, con el xml en las anotaciones
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Please insert JWT with Bearer into field",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //   {
                //     new OpenApiSecurityScheme
                //     {
                //       Reference = new OpenApiReference
                //       {
                //         Type = ReferenceType.SecurityScheme,
                //         Id = "Bearer"
                //       }
                //      },
                //      new string[] { }
                //    }
                //  });
            });

            // REMARK: If you want to use Controllers, you'll need this.
            //services.AddControllers();

            //services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
