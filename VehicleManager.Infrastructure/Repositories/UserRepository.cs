using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            IQueryable<Vehicle> userVehicles = _context.Vehicles.Where(x => x.ApplicationUserID == userId);

            return userVehicles;
        }
    }
}
