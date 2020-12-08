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
        public DbSet<Refueling> Refulings { get; set; }
        public DbSet<UnitOfFuel> UnitOfFuels { get; set; }
        public DbSet<CarHistory> CarHistories { get; set; }
        public DbSet<FuelForRefueling> FuelForRefuelings { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Refueling>()
            .HasOne(a => a.CarHistory)
            .WithOne(b => b.Refuling)
            .HasForeignKey<CarHistory>(b => b.RefulingRef);
        }
    }
}
