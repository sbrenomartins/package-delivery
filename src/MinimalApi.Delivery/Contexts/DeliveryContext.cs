using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Delivery.Contexts
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations => Set<Location>();
    }
}
