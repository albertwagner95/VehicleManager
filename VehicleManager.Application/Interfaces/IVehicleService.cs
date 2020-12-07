using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.ViewModels;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Application.ViewModels.Vehicle;

namespace VehicleManager.Application.Interfaces
{
    public interface IVehicleService
    {
        int AddVehicle(NewVehicleVm vehicle);
        void DeleteVehicle(DeleteVehicleVm vehicle);
        void EditVehicle(NewVehicleVm vehicle);
        List<VehicleFuelTypeVm> GetAllFuelsTypes();
        IQueryable<VehicleBrandNameVm> GetAllBrandNames();
        IQueryable<VehicleTypeVm> GetVehicleTypes();
        VehicleDetailsVm GetVehicleDetails(int vehicleId);
        NewVehicleVm GetVehicleForEdit(int? vehicleId);
        DeleteVehicleVm GetVehicleForDelete(int? vehicleId);
        string GetFuelTypeName(int fuelTypeId);
        string GetBrandName(int brandNameId);
        string GetTypeName(int typeId);
        ListForUserCarsForListVm GetUserCars(string userId);
        ListForUnitOfFuelForListVm GetUnitsOfFuels();
        ListFuelTypeForRefuelingForListVm GetAllFuelsTypesForRefuling();
        ListCarHistoryForListVm GetUserVehicleHistory(string userId);
        NewCarHistoryVm ReturnCarHistoryToAdd(string kindOfEvent, string userId);
        bool AddRefuling(NewRefulingVm model, NewCarHistoryVm carHistoryVm);
        int GetLastRefuelingMileage(int vehicleId);
        RefuelDetailsVm GetRefuelById(string refuelingId);
        string GetVehicleNameById(int vehicleId);
        string GetUnitsOfFuelNameById(int unitOfFuelId);
        string GetFuelNameById(int fuelForRefuelingId);
    }
}
