using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Model;

namespace VehicleManager.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserVehicles()
        {
            var userCars = _userService.GetUserVehicles(_userManager.GetUserId(User));
            return View(userCars);
        }

        public IActionResult UserAddresses()
        {
            var userAddresses = _userService.GetUserAddresses(_userManager.GetUserId(User));
            if(userAddresses == null || userAddresses.Count == 0)
            {
                TempData["succesMessage"] = "Brak danych do wyświetlenia!";
            }
            return View(userAddresses);
        }
    }
}
