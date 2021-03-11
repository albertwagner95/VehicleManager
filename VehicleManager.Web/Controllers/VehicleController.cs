using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IVehicleService vehicleService, UserManager<ApplicationUser> userManager, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _userManager = userManager;
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VehicleDetails(int id)
        {
            VehicleDetailsVm model = _vehicleService.GetVehicleDetails(id);
            
            if (model == null )
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
                TempData["tmpDataSuccess"] = $"Pomyślnie dodano pojazd {id}";
                return RedirectToAction("UserVehicles", "User");
            }
            else
            {
                TempData["tmpDataNoneSuccess"] = $"Nie dodano pojazdu. Skontaktuj się z administratorem.";
                return RedirectToAction("UserVehicles", "User");
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

        public IActionResult AddEvent()
        {
            var model = new NewEventVm()
            {
                UserCars = _vehicleService.GetUserCars(_userManager.GetUserId(User)),
                VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling(),
                UnitOfFuelForList = _vehicleService.GetUnitsOfFuels(),
                EventsListVm = _vehicleService.GetAllKindsOfEvents()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEvent(NewEventVm model)
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
            if (model.EventsListId != 1)
            {
                ModelState.Remove("AmountOfFuel");
                ModelState.Remove("PetrolStationName");
                ModelState.Remove("PriceForOneUnit");
                ModelState.Remove("IsRefulingFull");
                ModelState.Remove("FuelForRefuelingId");
                ModelState.Remove("UnitOfFuelId");
            }
            else if (model.EventsListId == 1)
            {
                ModelState.Remove("PriceForEvent");
            }
            if (!ModelState.IsValid)
            {
                model.VehicleFuelTypes = _vehicleService.GetAllFuelsTypesForRefuling();
                model.UnitOfFuelForList = _vehicleService.GetUnitsOfFuels();
                model.UserCars = _vehicleService.GetUserCars(_userManager.GetUserId(User));
                model.EventsListVm = _vehicleService.GetAllKindsOfEvents();
                return View(model);
            }
            var carHistory = _vehicleService.ReturnCarHistoryToAdd(model.EventsListId, _userManager.GetUserId(User));
            var isAddedRefuelingCorrectly = _vehicleService.AddEvent(model, carHistory);
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
        public IActionResult VehicleHistory(int VehicleId)
        {
            var cars = _vehicleService.GetUserCars(_userManager.GetUserId(User));
            ListCarHistoryForListVm historyForVehicle = new ListCarHistoryForListVm();
            if (VehicleId > 0)
            {
                historyForVehicle.CarHistoryList = _vehicleService.GetUserVehicleHistory(_userManager.GetUserId(User))
                    .CarHistoryList
                    .Where(x => x.VehicleId == VehicleId)
                    .ToList();
            }
            else
            {
                historyForVehicle = _vehicleService.GetUserVehicleHistory(_userManager.GetUserId(User));
            }

            if (historyForVehicle.CarHistoryList.Count == 0)
            {
                TempData["emptyCarHistory"] = "Brak danych do wyświetlenia";
            }
            historyForVehicle.UserCars = cars;
            return View(historyForVehicle);
        }
        public IActionResult EventDetails(string id)
        {
            EventDetailsVm refueling = _vehicleService.GetRefuelById(id);
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
        public IActionResult DeleteEvent(string eventId)
        {
            if (eventId == null)
            {
                return NotFound();
            }
            var isDelete = _vehicleService.DeleteEvent(eventId);
            if (isDelete == true)
            {
                TempData["deleteOperation"] = $"Pomyślnie usunięto zdarzenie {eventId}";
            }
            else
            {
                TempData["deleteOperation"] = "Nie udało się usunąć zdarzenia. Skontaktuj się z obsługą techniczną.";
            }
            return RedirectToAction("VehicleHistory", "Vehicle");

        } 
        public IActionResult VehicleStats(int id, string startDay, string endDay)
        {
            ViewData["startDay"] = startDay;
            ViewData["endDay"] = endDay;
            var vehicleEvents = _vehicleService.GetEventsBetweenTwoDates(id, startDay, endDay).OrderBy(x => x.EventDate).ToList();

            List<DataPointVehicleStatsVm> dataPoints1 = new List<DataPointVehicleStatsVm>();
            List<DataPointVehicleStatsVm> dataPoints2 = new List<DataPointVehicleStatsVm>();
            List<DataPointVehicleStatsVm> dataPoints3 = new List<DataPointVehicleStatsVm>();

            foreach (var item in vehicleEvents)
            {
                dataPoints1.Add(new DataPointVehicleStatsVm(item.EventDate.ToString("yyyy MMM"), item.MeterStatus));
                dataPoints2.Add(new DataPointVehicleStatsVm(item.EventDate.ToString("yyyy MMM"), (double)item.PriceForEvent));
                dataPoints3.Add(new DataPointVehicleStatsVm(item.EventDate.ToString("yyyy MMM"), (double)item.BurningFuelPerOneHundredKilometers));
            }

            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);

            ListVehicleStatsVm vehicleStatsTab = new ListVehicleStatsVm();
            vehicleStatsTab.VehicleStats = new VehicleStatsVm[4];
            vehicleStatsTab.VehicleStats[0] = _vehicleService.GetVehicleStats(id, startDay, endDay);
            vehicleStatsTab.VehicleStats[1] = _vehicleService.GetVehicleStats(id, DateTime.Today.AddDays(-7).ToString(), DateTime.Today.ToString());
            vehicleStatsTab.VehicleStats[2] = _vehicleService.GetVehicleStats(id, DateTime.Today.AddDays(-30).ToString(), DateTime.Today.ToString());
            vehicleStatsTab.VehicleStats[3] = _vehicleService.GetVehicleStats(id, DateTime.Today.AddDays(-180).ToString(), DateTime.Today.ToString());
            //_logger.LogError("VehicleStats");
            return View(vehicleStatsTab);
        }

    }
}