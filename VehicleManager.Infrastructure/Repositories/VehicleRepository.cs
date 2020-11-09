using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Context _context;
        public VehicleRepository(Context context)
        {
            _context = context;
        }

        public void DeleteVehicle(int? vehicleId)
        {
            var vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }

        public int AddVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
                return vehicle.Id;
            }
            return 0;
        }

        public IQueryable<VehicleBrandName> GetVehicleBrandNames()
        {
            IQueryable<VehicleBrandName> vehiclesNames = _context.VehicleBrandNames;
            return vehiclesNames;
        }

        public IQueryable<VehicleFuelType> GetVehicleFuelTypes()
        {
            IQueryable<VehicleFuelType> types = _context.VehicleFuelTypes;
            return types;
        }

        public IQueryable<VehicleType> GetVehicleTypes()
        {
            IQueryable<VehicleType> types = _context.VehicleTypes;
            return types;
        }




        //public IQueryable<Vehicle> GetVehicleByUserId(string userId)
        //{
        //    var vehicles = _context.Vehicles.Where(a => a.ApplicationUserID.Equals(userId));
        //    return vehicles;
        //}

        public Vehicle GetVehicleById(int? vehicleId)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(a => a.Id == vehicleId);
            return vehicle;
        }

    }
}
