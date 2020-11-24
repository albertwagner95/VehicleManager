using VehicleManager.Application.ViewModels.UserModels;

namespace VehicleManager.Application.Interfaces
{
    public interface IUserService
    {
        ListUserCarsForList GetUserVehicles(string userId);
    }
}
