using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Table4URest.Server.Configurations.Entities;
using Table4URest.Server.Models;
using Table4URest.Shared.Domain;

namespace Table4URest.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LocationFilter> LocationFilters { get; set; }
        public DbSet<PriceFilter> PriceFilters { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ServeFilter> ServeFilters { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new LocationFilterSeedConfiguration());
            builder.ApplyConfiguration(new ServeFilterSeedConfiguration());
            builder.ApplyConfiguration(new PriceFilterSeedConfiguration());
            builder.ApplyConfiguration(new StaffSeedConfiguration());

        }

    }
}
