using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.AddressModels;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Infrastructure
{
    public class Context : IdentityDbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<VehicleFuelType> VehicleFuelTypes { get; set; }
        public DbSet<VehicleBrandName> VehicleBrandNames { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<BaseAddress> BaseAddress { get; set; }
        public DbSet<Voivodeship> Voivodeships { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<CityType> CityTypes { get; set; }
        public DbSet<Community> Communities { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
