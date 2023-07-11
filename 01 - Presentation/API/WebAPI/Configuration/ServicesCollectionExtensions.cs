using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebAPI.Configuration;
public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Projeto DDD .NET Core 7",
                Version = "v1",
                Description = "Projeto DDD .NET Core 7",
                Contact = new OpenApiContact
                {
                    Name = "Guilherme F Maurila",
                    Email = "gfmaurila@gmail.com",
                    Url = new Uri("https://github.com/gfmaurila"),
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
