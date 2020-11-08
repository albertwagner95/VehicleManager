using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Domain.Model;

namespace VehicleManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<Vehicle> GetAllUserVehicles(string userId);
        
    }
}
