using System.Linq;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;

namespace VehicleManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Vehicle> GetAllUserVehicles(string userId)
        {
            IQueryable<Vehicle> userVehicles = _context.Vehicles
                .Where(x => x.ApplicationUserID == userId && x.IsActive == true);

            return userVehicles;
        }
    }
}
