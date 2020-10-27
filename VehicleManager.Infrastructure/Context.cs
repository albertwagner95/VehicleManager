using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VehicleManager.Domain.Model;

namespace VehicleManager.Infrastructure
{
    public class Context : IdentityDbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CarHistory> CarHistories { get; set; }
        public DbSet<KindOfFuel> KindOfFuels { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleOwner> VehicleOwners { get; set; }
        public DbSet<VehicleService> VehicleServices { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleUser> VehicleUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AddressType>()
                .HasOne(a => a.Address).WithOne(b => b.AddressType)
                .HasForeignKey<Address>(e => e.AddressTypeRef);

            builder.Entity<City>()
               .HasOne(a => a.Address).WithOne(b => b.City)
               .HasForeignKey<Address>(e => e.CityRef);

            builder.Entity<ZipCode>()
               .HasOne(a => a.Address).WithOne(b => b.ZipCode)
               .HasForeignKey<Address>(e => e.ZipCodeRef);

            builder.Entity<Country>()
               .HasOne(a => a.Address).WithOne(b => b.Country)
               .HasForeignKey<Address>(e => e.CountryRef);

            builder.Entity<VehicleOwner>()
               .HasOne(a => a.Address).WithOne(b => b.VehicleOwner)
               .HasForeignKey<Address>(e => e.VehicleOwnerRef);

            builder.Entity<VehicleUser>()
               .HasOne(a => a.Address).WithOne(b => b.VehicleUser)
               .HasForeignKey<Address>(e => e.VehicleUserRef);

            builder.Entity<KindOfFuel>()
                .HasOne(a => a.Vehicle).WithOne(b => b.KindOfFuel)
                .HasForeignKey<Vehicle>(e => e.KindOfFuelRef);

            builder.Entity<VehicleType>()
                .HasOne(a => a.Vehicle).WithOne(b => b.VehicleType)
                .HasForeignKey<Vehicle>(e => e.VehicleTypeRef);

            builder.Entity<VehicleModel>()
                .HasOne(a => a.Vehicle).WithOne(b => b.VehicleModel)
                .HasForeignKey<Vehicle>(e => e.VehicleModelRef);

            builder.Entity<VehicleBrand>()
                .HasOne(a => a.Vehicle).WithOne(b => b.VehicleBrand)
                .HasForeignKey<Vehicle>(e => e.VehicleBrandRef);




        }
    }
}
