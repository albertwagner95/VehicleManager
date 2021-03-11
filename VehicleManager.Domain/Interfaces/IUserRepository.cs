using System.Linq;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.AddressModels;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<Vehicle> GetAllUserVehicles(string userId);
        IQueryable<Address> GetAllUserAddresses(string userId);

    }
}
