using System.Linq;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.AddressModels;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Address> GetAllUserAddresses(string userId)
        {
            IQueryable<Address> userAddresses = _context.Addresses
                .Where(x => x.ApplicationUserID == userId && x.IsActive == true);

            return userAddresses;
        }

        public IQueryable<Vehicle> GetAllUserVehicles(string userId)
        {
            IQueryable<Vehicle> userVehicles = _context.Vehicles
                .Where(x => x.ApplicationUserID == userId && x.IsActive == true);

            return userVehicles;
        }
    }
}