using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Delivery.Modules
{
    public class DeliveryModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/delivery/{packageId}/history", async (DeliveryContext context, int packageId) =>
                await context.Locations.Where(x => x.Id == packageId)
                                       .OrderByDescending(x => x.Id)
                                       .ToListAsync());

            app.MapPost("/delivery", async (DeliveryContext context, PackageLocation dto) =>
            {
                context.Locations.Add(new Location()
                {
                    Id = dto.Id,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude,
                });

                await context.SaveChangesAsync();

                return Results.Created($"/delivery/{dto.Id}", dto);
            });
        }
    }
}
