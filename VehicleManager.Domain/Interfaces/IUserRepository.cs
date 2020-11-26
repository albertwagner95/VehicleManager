using System.Linq;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<Vehicle> GetAllUserVehicles(string userId);
        IQueryable<Address> GetAllUserAddresses(string userId);

    }
}
