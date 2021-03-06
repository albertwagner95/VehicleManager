﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                //_context.Vehicles.Remove(vehicle);
                vehicle.IsActive = false;
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

        public Vehicle GetVehicleById(int? vehicleId)
        {
            var vehicle = _context.Vehicles
                .FirstOrDefault(a => a.Id == vehicleId && a.IsActive == true);
            return vehicle;
        }

        public void EditVehicle(Vehicle vehicle)
        {
            _context.Attach(vehicle);
            _context.Entry(vehicle).Property("Millage").IsModified = true;
            _context.Entry(vehicle).Property("DateOfFirstRegistration").IsModified = true;
            _context.Entry(vehicle).Property("Model").IsModified = true;
            _context.Entry(vehicle).Property("IsRegisterdInPoland").IsModified = true;
            _context.Entry(vehicle).Property("ProductionDate").IsModified = true;
            _context.Entry(vehicle).Property("RegistrationNumber").IsModified = true;
            _context.Entry(vehicle).Property("EnginePower").IsModified = true;
            _context.Entry(vehicle).Property("EngineCapacity").IsModified = true;
            _context.Entry(vehicle).Property("PermissibleGrossWeight").IsModified = true;
            _context.Entry(vehicle).Property("OwnWeight").IsModified = true;
            _context.Entry(vehicle).Property("ModifiedById").IsModified = true;
            _context.Entry(vehicle).Property("ModifiedDateTime").IsModified = true;
            _context.Entry(vehicle).Property("VehicleBrandNameId").IsModified = true;
            _context.Entry(vehicle).Property("VehicleFuelTypeId").IsModified = true;
            _context.Entry(vehicle).Property("VehicleTypeId").IsModified = true;
            _context.Entry(vehicle).Property("IsGasInstalation").IsModified = true;

            _context.SaveChanges();
        }

        public IQueryable<Vehicle> GetVehicles()
        {
            return _context.Vehicles;
        }

        public IQueryable<UnitOfFuel> GetUnitsOfFuel()
        {
            return _context.UnitOfFuels;
        }

        public bool AddRefueling(Refueling refuelingModelToAdd, string userId, CarHistory carHistory)
        {
            if (refuelingModelToAdd is null)
            {
                return false;
            }
            else
            {
                refuelingModelToAdd.Id = Guid.NewGuid().ToString();
                _context.Refulings.Add(refuelingModelToAdd);
                refuelingModelToAdd.CreatedDateTime = DateTime.Now;
                carHistory.VehicleId = refuelingModelToAdd.VehicleId;
                carHistory.RefulingRef = refuelingModelToAdd.Id;
                _context.CarHistories.Add(carHistory);

                _context.Vehicles.FirstOrDefault(x => x.Id == refuelingModelToAdd.VehicleId).Millage = refuelingModelToAdd.MeterStatus;

                _context.SaveChanges();
                return true;
            }
        }

        public IQueryable<FuelForRefueling> GetFuelTypesForRefueling()
        {
            var fuelForRefulings = _context.FuelForRefuelings;
            return fuelForRefulings;
        }
        public IQueryable<Refueling> GetAllRefuelings()
        {
            var refuelings = _context.Refulings.Where(x => x.IsActive == true);
            return refuelings;
        }
        public IQueryable<CarHistory> GetAllVehicleHistory()
        {
            var vehicleHistory = _context.CarHistories;
            return vehicleHistory;
        }

        public Refueling GetRefuelingById(string refuelingId)
        {
            var refueling = _context.Refulings.FirstOrDefault(x => x.Id.Equals(refuelingId));
            if (refueling is null) return null;
            return refueling;
        }

        public bool DeleteRefueling(string refuelingId, CarHistory vehicleHistory, Vehicle vehicle)
        {
            var refueling = _context.Refulings.Find(refuelingId);

            if (refueling != null && vehicleHistory != null)
            {
                refueling.IsActive = false;
                _context.Attach(vehicleHistory);
                _context.Entry(vehicleHistory).Property("IsActive").IsModified = true;

                _context.Attach(vehicle);
                _context.Entry(vehicle).Property("Millage").IsModified = true;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool EditRefueling(Refueling vehicleForUpdate)
        {
            if (vehicleForUpdate is null) return false;

            _context.Attach(vehicleForUpdate);
            _context.Entry(vehicleForUpdate).Property("AmountOfFuel").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("FuelPrice").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("PriceForOneUnit").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("MeterStatus").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("PetrolStationName").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("IsRefulingFull").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("Varnings").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("VehicleId").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("BurningFuelPerOneHundredKilometers").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("UnitOfFuelId").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("FuelForRefuelingId").IsModified = true;
            _context.Entry(vehicleForUpdate).Property("ModifiedDateTime").IsModified = true;

            _context.SaveChanges();

            return true;
        }
    }
}
