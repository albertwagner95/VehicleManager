using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Model;

namespace VehicleManager.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<IdentityUser> _userManager;

        public VehicleController(IVehicleService vehicleService, UserManager<IdentityUser> userManager)
        {
            _vehicleService = vehicleService;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VehicleDetails(int id)
        {
            var model = _vehicleService.GetVehicleDetails(id);
            if (model == null)
            {
                ViewBag.NullVehicles = "Brak pojazdów do wyświetlenia";
                return View();
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddVehicle()
        {
            var userId = _userManager.GetUserId(User);


            var model = new NewVehicleVm()
            {
                VehicleFuelTypes = _vehicleService.GetAllFuelsTypes().ToList(),
                VehicleBrandNames = _vehicleService.GetAllBrandNames().ToList(),
                VehicleTypes = _vehicleService.GetVehicleTypes().ToList(),
                ApplicationUserID = userId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVehicle(NewVehicleVm models)
        {
            if (!ModelState.IsValid)
            {
                models.VehicleFuelTypes = _vehicleService.GetAllFuelsTypes().ToList();
                models.VehicleBrandNames = _vehicleService.GetAllBrandNames().ToList();
                models.VehicleTypes = _vehicleService.GetVehicleTypes().ToList();
                return View(models);
            }
            var id = _vehicleService.AddVehicle(models);
            if (id != 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(models);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Ok(400);
            }
            var vehicleToDelete = _vehicleService.GetVehicleForDelete(id);
            if (vehicleToDelete == null)
            {
                return Ok(400);
            }
            return View(vehicleToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteVehicleVm vehicleToDelete)
        {
            _vehicleService.DeleteVehicle(vehicleToDelete);
            return RedirectToAction("UserVehicles", "User");
        }
    }
}
