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
            var model = _vehicleService.GetVehicleDetails(id);
            if (model == null)
            {
                ViewBag.NullVehicles = "Nie znaleziono takiego pojazdu";
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
                return RedirectToAction("User", "UserVehicles");
            }
            else
            {
                return View(models);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
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
        public IActionResult Delete(DeleteVehicleVm vehicleToDelete)
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
                VehiclesList = _vehicleService.GetUserCars(_userManager.GetUserId(User)),
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
                TempData["InCorrectOperation"] = "Tankowanie nie dodane, skontaktuj się z pomocą techniczną aby zgłosić błąd, lub spróbuj ponownie!";
                return RedirectToAction("VehicleHistory", "Vehicle", new { id = model.VehicleId });
            }
            if (model.VehicleId != 0)
            {
                model.LastMeters = _vehicleService.GetLastRefuelingMileage(model.VehicleId);
            }

            if (model.MeterStatus < model.LastMeters)
            {
                ModelState.AddModelError("MeterStatus", $"Aktualny przebieg, nie może być niższy od poprzedniego - {model.LastMeters} km, edytuj przebieg pojazdu, lub wpisz inną wartość!");
            }
            if (!ModelState.IsValid)
            {
                model.VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling();
                model.UnitOfFuelForList = _vehicleService.GetUnitsOfFuels();
                model.VehiclesList = _vehicleService.GetUserCars(_userManager.GetUserId(User));
                return View(model);
            }
            var carHistory = _vehicleService.ReturnCarHistoryToAdd("Tankowanie", _userManager.GetUserId(User));
            var isAddedRefuelingCorrectly = _vehicleService.AddRefuling(model, carHistory);
            if (isAddedRefuelingCorrectly == true)
            {
                TempData["CorrectOperation"] = "Pomyślnie dodano tankowanie!";
            }
            else
            {
                TempData["InCorrectOperation"] = "Tankowanie nie dodane, skontaktuj się z pomocą techniczną aby zgłosić błąd, lub spróbuj ponownie!";
            }

            return RedirectToAction("VehicleHistory", "Vehicle", new { id = model.VehicleId });
        }
        public IActionResult VehicleHistory(int id)
        {
            var historyForVehicle = _vehicleService.GetUserVehicleHistory(_userManager.GetUserId(User), id);
            if (historyForVehicle == null)
            {
                TempData["InCorrectOperation"] = "Brak danych do wyświetlenia";
            }
            return View(historyForVehicle);
        }

        public IActionResult RefuelingDetails(string id)
        {
            RefuelDetailsVm refueling = _vehicleService.GetRefuelById(id);
            if (refueling == null)
            {
                ViewBag.NullVehicles = "Nie znaleziono takiego tankowania";
                return View();
            }
            refueling.VehicleName = _vehicleService.GetVehicleNameById(refueling.VehicleId);
            refueling.UnitOfFuelName = _vehicleService.GetUnitsOfFuelNameById(refueling.UnitOfFuelId);
            refueling.FuelName = _vehicleService.GetFuelNameById(refueling.FuelForRefuelingId);
            return View(refueling);
        }
        [HttpGet]
        public IActionResult RemoveRefueling(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var refueling = _vehicleService.GetRefuelById(id);
            if (refueling == null)
            {
                return NotFound();
            }
            return View(refueling);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveRefueling(RefuelDetailsVm refueling)
        {
            var vehicleId = refueling.VehicleId;
            if (refueling == null)
            {
                TempData["InCorrectOperation"] = "Nie udało się usunąć tankowania";
                return RedirectToAction("VehicleHistory", "Vehicle", new { id = refueling.VehicleId });
            }
            bool isRemove = _vehicleService.DeleteRefueling(refueling.Id);
            if (isRemove == true)
            {
                TempData["CorrectOperation"] = $"Pomyślnie usunąłeś tankowanie z dnia {refueling.CreateDate}";
                return RedirectToAction("VehicleHistory", "Vehicle", new { id = vehicleId });
            }
            return RedirectToAction("VehicleHistory", "Vehicle", new { id = vehicleId });

        }

        [HttpGet]
        public IActionResult EditRefueling(string id)
        {
            NewRefulingVm refueling = _vehicleService.GetRefulingForEditById(id);
            refueling.VehiclesList = _vehicleService.GetUserCars(_userManager.GetUserId(User));
            refueling.VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling();
            refueling.UnitOfFuelForList = _vehicleService.GetUnitsOfFuels();
            return View(refueling);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRefueling(NewRefulingVm refueling)
        {
            if (refueling is null)
            {
                TempData["InCorrectOperation"] = "Nie udało się edytować tankowania";
                return RedirectToAction("VehicleHistory", "Vehicle", new { id = refueling.VehicleId });
            }

            if (refueling.VehicleId != 0)
            {
                refueling.LastMeters = _vehicleService.GetLastRefuelingMileage(refueling.VehicleId);
            }

            if (refueling.MeterStatus < refueling.LastMeters)
            {
                ModelState.AddModelError("MeterStatus", $"Aktualny przebieg, nie może być niższy od poprzedniego - {refueling.LastMeters} km, edytuj przebieg pojazdu, lub wpisz inną wartość!");
            }
            if (!ModelState.IsValid)
            {
                refueling.VehiclesList = _vehicleService.GetUserCars(_userManager.GetUserId(User));
                refueling.VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling();
                refueling.UnitOfFuelForList = _vehicleService.GetUnitsOfFuels();
                return View(refueling);
            }
            _vehicleService.EditRefueling(refueling);
            TempData["CorrectOperation"] = "Udało się edytować tankowanie";

            return RedirectToAction("VehicleHistory", "Vehicle", new { id = refueling.VehicleId });
        }
    }
}