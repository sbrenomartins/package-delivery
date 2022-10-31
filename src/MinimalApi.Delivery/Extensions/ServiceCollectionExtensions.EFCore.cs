using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Delivery.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddEFCore(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DeliveryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

            return builder;
        }

        public static async Task<IApplicationBuilder> MigrateData(this IApplicationBuilder app)
        {
            using (var db = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DeliveryContext>())
            {
                await db.Database.MigrateAsync();
            }

            return app;
        }
    }
}
