using System.Linq;
using VehicleManager.Domain.Model;

namespace VehicleManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<Vehicle> GetAllUserVehicles(string userId);
        
    }
}
