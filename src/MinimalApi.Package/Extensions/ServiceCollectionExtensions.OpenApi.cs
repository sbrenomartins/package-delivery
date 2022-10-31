using Microsoft.OpenApi.Models;

namespace MinimalApi.Package.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddOpenApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();

            return builder;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "MAPI - Packages",
                    Title = "MAPI - Packages",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Developers",
                        Email = "teste@minimalapi.com"
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.RoutePrefix = routePrefix;
            });

            return app;
        }
    }
}
