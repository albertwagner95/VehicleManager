using System.Linq;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        void DeleteVehicle(int? vehicleId);
        void EditVehicle(Vehicle vehicle);
        int AddVehicle(Vehicle vehicl);
        IQueryable<VehicleFuelType> GetVehicleFuelTypes();
        IQueryable<VehicleBrandName> GetVehicleBrandNames();
        IQueryable<VehicleType> GetVehicleTypes();
        //IQueryable<Vehicle> GetVehicleByUserId(string userId);
        Vehicle GetVehicleById(int? vehicleId);
        IQueryable<Vehicle> GetVehicles();
        IQueryable<UnitOfFuel> GetUnitsOfFuel();
        bool AddRefueling(Refueling refuelingModelToAdd, string userId, CarHistory carHistory);
        IQueryable<FuelForRefueling> GetFuelTypesForRefueling();
        IQueryable<CarHistory> GetAllVehicleHistory();
        IQueryable<Refueling> GetAllRefuelings();
        Refueling GetRefuelingById(string refuelingId);
        bool DeleteRefueling(string refuelingId,CarHistory vehicleHistory, Vehicle vehicle);
        bool EditRefueling(Refueling vehicleForUpdate);
    }
}
