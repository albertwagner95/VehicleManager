﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        //void DeleteVehicle(int vehicleId); 
        //int AddVehicle(Vehicle vehicle);
        
        int AddVehicle(Vehicle vehicl);
        IQueryable<VehicleFuelType> GetVehicleFuelTypes();
        IQueryable<VehicleBrandName> GetVehicleBrandNames();
        IQueryable<VehicleType> GetVehicleTypes();
        //IQueryable<Vehicle> GetVehicleByUserId(string userId);
        //Vehicle GetVehicleById(int vehicleId);
    }
}