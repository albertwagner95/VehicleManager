using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Model;

namespace VehicleManager.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VehicleController(IVehicleService vehicleService, UserManager<ApplicationUser> userManager)
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

            //GetFuelTypeName
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
                models.VehicleFuelTypes = _vehicleService.GetAllFuelsTypes();
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

        [HttpGet]
        public IActionResult EditVehicle(int? id)
        {
            NewVehicleVm vehicle = _vehicleService.GetVehicleForEdit(id);

            vehicle.YearHelper = vehicle.ProductionDate.Year;
            vehicle.VehicleFuelTypes = _vehicleService.GetAllFuelsTypes().ToList();
            vehicle.VehicleBrandNames = _vehicleService.GetAllBrandNames().ToList();
            vehicle.VehicleTypes = _vehicleService.GetVehicleTypes().ToList();
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditVehicle(NewVehicleVm vehicle)
        {
            if (vehicle is null)
            {
                throw new System.ArgumentNullException(nameof(vehicle));
                //add viewbag?
            }

            if (!ModelState.IsValid)
            {
                vehicle.YearHelper = vehicle.ProductionDate.Year;
                vehicle.VehicleFuelTypes = _vehicleService.GetAllFuelsTypes();
                vehicle.VehicleBrandNames = _vehicleService.GetAllBrandNames().ToList();
                vehicle.VehicleTypes = _vehicleService.GetVehicleTypes().ToList();
                return View(vehicle);
            }
            _vehicleService.EditVehicle(vehicle);

            return RedirectToAction("UserVehicles", "User");
        }

        public IActionResult AddRefueling()
        {
            var model = new NewRefulingVm()
            {
                UserCars = _vehicleService.GetUserCars(_userManager.GetUserId(User)),
                VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling(),
                UnitOfFuelForList = _vehicleService.GetUnitsOfFuels()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRefueling(NewRefulingVm model)
        {
            if (model is null)
            {
                TempData["refuellingSuccessfullyOrNotAdded"] = "Tankowanie nie dodane, skontaktuj się z pomocą techniczną aby zgłosić błąd, lub spróbuj ponownie!";
            }
            if (!ModelState.IsValid)
            {
                model.UserCars = _vehicleService.GetUserCars(_userManager.GetUserId(User));
                model.VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling();
                model.UnitOfFuelForList = _vehicleService.GetUnitsOfFuels();
                model.VehiclesList = _vehicleService.GetUserCars(_userManager.GetUserId(User));
                return View(model);
            }
            var isAddedRefuelingCorrectly = _vehicleService.AddRefuling(model);
            if (isAddedRefuelingCorrectly == true)
            {
                TempData["refuellingSuccessfullyOrNotAdded"] = "Pomyślnie dodano tankowanie!";
            }
            else
            {
                TempData["refuellingSuccessfullyOrNotAdded"] = "Tankowanie nie dodane, skontaktuj się z pomocą techniczną aby zgłosić błąd, lub spróbuj ponownie!";
            }

            return View("UserVehicles", "User");
            //return RedirectToAction("CarHistory", "Vehicle");
        }
    }
}