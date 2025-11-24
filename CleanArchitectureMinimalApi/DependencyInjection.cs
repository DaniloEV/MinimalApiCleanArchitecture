using Asp.Versioning;
using Asp.Versioning.Builder;
using CleanArchitectureMinimalApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArchitectureMinimalApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            #region versioning
            //para el caso de controllers , es necesario colocarle AddMvc y la librería
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                //esto es para indicar cuales api's tienen soporte y cuales van a estar deprecadas, aunque para la version de minimal api se puede hacer diferente
                options.ReportApiVersions = true;
                //me define que tipo de version de api vamos a utilizar, si con query's, si con headers o por URL, también se pueden combinar
                // ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersion("mi-version"))
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                //El addApiExplorer me permite indicar que grupo de formato de versión voy a estar utilizando, es un wildcard principalmente
                options.GroupNameFormat = "'v'VVV";
                // va a sustituir mi versión por defecto de mi URL, en todos mis swagger endpoints
                options.SubstituteApiVersionInUrl = true;
                //una vez configurado esto, a configurar el enrutamiento, hay 3 maneras, una individual por controller (no recomendable), por grupos (es buena pero sigue siendo individual) y de
                //manera general, para ello lo hacemos  en el program
            });
            //para el swagger
            
          
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigSwaggerGenOptions>();
            #endregion

            services.AddEndpointsApiExplorer();
          

            // REMARK: If you want to use Controllers, you'll need this.
            //services.AddControllers();

            //services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
