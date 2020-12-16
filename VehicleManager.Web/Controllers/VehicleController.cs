﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
                VehicleBrandNames = _vehicleService.GetAllBrandNames(),
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
                models.VehicleBrandNames = _vehicleService.GetAllBrandNames();
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
            vehicle.VehicleBrandNames = _vehicleService.GetAllBrandNames();
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
                vehicle.VehicleBrandNames = _vehicleService.GetAllBrandNames();
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
                model.UserCars = _vehicleService.GetUserCars(_userManager.GetUserId(User));
                return View(model);
            }
            var carHistory = _vehicleService.ReturnCarHistoryToAdd("Tankowanie", _userManager.GetUserId(User));
            var isAddedRefuelingCorrectly = _vehicleService.AddRefuling(model, carHistory);
            if (isAddedRefuelingCorrectly == true)
            {
                TempData["refuellingSuccessfullyOrNotAdded"] = "Pomyślnie dodano tankowanie!";
            }
            else
            {
                TempData["refuellingSuccessfullyOrNotAdded"] = "Tankowanie nie dodane, skontaktuj się z pomocą techniczną aby zgłosić błąd, lub spróbuj ponownie!";
            }

            return RedirectToAction("VehicleHistory", "Vehicle");
        }
        public IActionResult VehicleHistory()
        {
            var historyForVehicle = _vehicleService.GetUserVehicleHistory(_userManager.GetUserId(User));
            if (historyForVehicle.CarHistoryList.Count == 0)
            {
                TempData["emptyCarHistory"] = "Brak danych do wyświetlenia";
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

        //[HttpGet]
        //public ActionResult DeleteEvent(string eventId, string eventTypeName)
        //{
        //    EventToDeleteVm eventToDelete = _vehicleService.GetEventToDelete(eventTypeName, eventId);
        //    if (eventToDelete == null)
        //    {
        //        TempData["refuellingSuccessfullyOrNotAdded"] = "Zdarzenie nie usunięte";
        //        return RedirectToAction("VehicleHistory", "Vehicle");
        //    }
        //    return View(eventToDelete);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteEvent(EventToDeleteVm eventToDelete)
        //{
        //    bool isDelete = _vehicleService.DeleteEvent(eventToDelete);
        //    if (isDelete == true)
        //    {
        //        TempData["refuellingSuccessfullyOrNotAdded"] = "Zdarzenie usunięte";
        //    }
        //    else
        //    {
        //        TempData["refuellingSuccessfullyOrNotAdded"] = "Zdarzenie nie usunięte, spróbuj ponownie lubc skontaktuj się z pomocą techniczną aby zgłosić błąd, lub spróbuj ponownie!";
        //    }
        //    return RedirectToAction("VehicleHistory", "Vehicle");
        //}

        // GET: Movies/Delete/5
        public IActionResult DeleteEvent(string eventId, string eventTypeName)
        {
            if (eventId == null)
            {
                return NotFound();
            }
            EventToDeleteVm eventModel = _vehicleService.GetEventToDelete(eventTypeName, eventId);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(EventToDeleteVm eventModel)
        {
            _vehicleService.DeleteEvent(eventModel);
            return RedirectToAction("VehicleHistory", "Vehicle");
        }
    }
}