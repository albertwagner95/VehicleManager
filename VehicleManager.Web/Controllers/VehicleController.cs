using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Model;

namespace VehicleManager.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public IActionResult Index()
        {


            return View();
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            var model = new NewVehicleVm()
            {
                VehicleFuelTypes = _vehicleService.GetAllFuelsTypes().ToList(),
                VehicleBrandNames = _vehicleService.GetAllBrandNames().ToList(),
                VehicleTypes = _vehicleService.GetVehicleTypes().ToList(),
                ApplicationUserID = "3a7f19b8-8d42-40c0-b178-b4a3aaf70ce2"
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
            return RedirectToAction("Index", "Home");
        }
    }
}
