using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Infrastructure
{
    public class Context : IdentityDbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<VehicleFuelType> VehicleFuelTypes { get; set; }
        public DbSet<VehicleBrandName> VehicleBrandNames { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
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

        }
    }
}
