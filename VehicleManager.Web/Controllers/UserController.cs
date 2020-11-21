using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels.UserModels;
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
    }
}
