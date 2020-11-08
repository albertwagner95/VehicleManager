using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Application.ViewModels.UserModels;

namespace VehicleManager.Application.Interfaces
{
    public interface IUserService
    {
        ListUserCarsForList GetUserVehicles(string userId);
    }
}
