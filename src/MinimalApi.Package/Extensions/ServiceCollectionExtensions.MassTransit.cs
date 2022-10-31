using MassTransit;

namespace MinimalApi.Package.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddMessages(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", h =>
                    {
                        h.Username("rabbit");
                        h.Password("P@ssword123");
                    });
                    config.ConfigureEndpoints(context);
                });
            });

            return builder;
        }
    }
}
