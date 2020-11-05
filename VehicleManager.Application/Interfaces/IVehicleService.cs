using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Application.ViewModels;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Model;

namespace VehicleManager.Application.Interfaces
{
    public interface IVehicleService
    {
        int AddVehicle(NewVehicleVm vehicle);
        IQueryable<VehicleFuelTypeVm> GetAllFuelsTypes();
        IQueryable<VehicleBrandNameVm> GetAllBrandNames();
        IQueryable<VehicleTypeVm> GetVehicleTypes();
    }
}
