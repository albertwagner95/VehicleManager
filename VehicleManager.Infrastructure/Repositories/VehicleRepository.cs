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
            var x = _context.Vehicles;
            return _context.Vehicles;
        }

        public IQueryable<UnitOfFuel> GetUnitsOfFuel()
        {
            return _context.UnitOfFuels;
        }

        public bool AddEvent(Event eventModelToAdd, string userId, CarHistory carHistory)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }
            if (carHistory is null)
            {
                return false;
            }
            if (eventModelToAdd is null)
            {
                return false;
            }
            else
            {

                _context.Events.Add(eventModelToAdd);
                carHistory.VehicleId = eventModelToAdd.VehicleId;
                carHistory.EventDate = eventModelToAdd.EventDate;
                carHistory.EventRef = eventModelToAdd.Id;
                _context.CarHistories.Add(carHistory);
                _context.Vehicles.FirstOrDefault(x => x.Id == eventModelToAdd.VehicleId).Millage = eventModelToAdd.MeterStatus;

                _context.SaveChanges();
                return true;
            }


        }

        public IQueryable<FuelForRefueling> GetFuelTypesForRefueling()
        {
            var fuelForRefulings = _context.FuelForRefuelings;
            return fuelForRefulings;
        }
        public IQueryable<Event> GetAllRefuelings()
        {
            var refuelings = _context.Events;
            return refuelings;
        }
        public IQueryable<CarHistory> GetAllVehicleHistory()
        {
            var vehicleHistory = _context.CarHistories;
            return vehicleHistory;
        }

        public Event GetRefuelingById(string refuelingId)
        {
            var refueling = _context.Events.FirstOrDefault(x => x.Id.Equals(refuelingId));
            if (refueling is null) return null;
            return refueling;
        }

        public bool DeleteEvent(string eventId)
        {
            if (eventId != null)
            {
                Event eventToDelete =  _context.Events.Find(eventId);
                eventToDelete.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Event> GetAllEvents()
        {
            var events = _context.Events;
            return events;
        }

        public IQueryable<KindOfEvent> GetAllKindOfEvents()
        {
            IQueryable<KindOfEvent> kindOfEvents = _context.KindfOfEvents;
            if (kindOfEvents.Any())
            {
                return kindOfEvents;
            }
            return null;
        }
    }
}
