using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services.Helpers;
using VehicleManager.Application.ViewModels;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
        public int AddVehicle(NewVehicleVm vehicle)
        {
            if (vehicle is null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            vehicle.Capacity = vehicle.PermissibleGrossWeight - vehicle.OwnWeight;
            vehicle.ProductionDate = new DateTime(vehicle.YearHelper, 1, 1);
            vehicle.Vin = vehicle.Vin.ToUpper();
            vehicle.RegistrationNumber = vehicle.RegistrationNumber.ToUpper();
            vehicle.Model = vehicle.Model.ToUpper();

            var vehicl = _mapper.Map<Domain.Model.VehicleModels.Vehicle>(vehicle);

            vehicl.CreatedDateTime = DateTime.Now;
            vehicl.CreatedById = "userid";
            vehicl.IsActive = true;

            var result = _vehicleRepository.AddVehicle(vehicl);
            return result; // result = 0 is false
        }

        public VehicleDetailsVm GetVehicleDetails(int vehicleId)
        {
            Vehicle vehicle = _vehicleRepository.GetVehicleById(vehicleId);

            if (vehicle != null)
            {
                var vehicleForVm = _mapper.Map<VehicleDetailsVm>(vehicle);

                vehicleForVm.VehicleFuelTypeName = GetFuelTypeName(vehicleForVm.VehicleFuelTypeId);
                vehicleForVm.VehicleBrandName = GetBrandName(vehicleForVm.VehicleBrandNameId);
                vehicleForVm.VehicleTypeName = GetTypeName(vehicleForVm.VehicleTypeId);
                vehicleForVm.ProductionDateString = vehicleForVm.ProductionDate.ToString("yyyy");
                vehicleForVm.DataOfFirstRegistrationString = vehicleForVm.DateOfFirstRegistration.ToString("D");

                return vehicleForVm;
            }
            else
            {
                return null;
            }
        }
        public List<VehicleBrandNameVm> GetAllBrandNames()
        {
            List<VehicleBrandNameVm> vehicleBrandNames = null;
            try
            {
                vehicleBrandNames = _vehicleRepository.GetVehicleBrandNames()
                .ProjectTo<VehicleBrandNameVm>(_mapper.ConfigurationProvider)
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Name)
                .ToList();
            }
            catch (Exception)
            {
                return null;
            }


            return vehicleBrandNames;
        }

        public ListFuelTypeForRefuelingForListVm GetAllFuelsTypesForRefuling()
        {
            var vehicleFuelTypesVm = _vehicleRepository.GetFuelTypesForRefueling()
                .ProjectTo<FuelTypeForRefuelingForListVm>(_mapper.ConfigurationProvider).ToList();

            var vehicleFuelTypeForRefueling = new ListFuelTypeForRefuelingForListVm();
            vehicleFuelTypeForRefueling.FuelTypeForRefuelingForLists = vehicleFuelTypesVm;

            return vehicleFuelTypeForRefueling;
        }

        public IQueryable<VehicleTypeVm> GetVehicleTypes()
        {
            var vehicleTypes = _vehicleRepository.GetVehicleTypes().ProjectTo<VehicleTypeVm>(_mapper.ConfigurationProvider);

            return vehicleTypes;
        }

        public void DeleteVehicle(DeleteVehicleVm vehicle)
        {
            if (vehicle != null)
            {
                var vehicl = _mapper.Map<Domain.Model.VehicleModels.Vehicle>(vehicle);
                _vehicleRepository.DeleteVehicle(vehicl.Id);
            }
        }

        public DeleteVehicleVm GetVehicleForDelete(int? vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);
            if (vehicle != null)
            {
                var vehicleForVm = _mapper.Map<DeleteVehicleVm>(vehicle);
                return vehicleForVm;
            }
            return null;
        }

        public NewVehicleVm GetVehicleForEdit(int? vehicleId)
        {

            if (vehicleId != null)
            {
                var vehicle = _vehicleRepository.GetVehicleById(vehicleId);
                var vehicleForVm = _mapper.Map<NewVehicleVm>(vehicle);
                return vehicleForVm;
            }
            return null;
        }

        public void EditVehicle(NewVehicleVm vehicle)
        {
            vehicle.ProductionDate = new DateTime(vehicle.YearHelper, 1, 1);
            vehicle.Vin = vehicle.Vin.ToUpper();
            vehicle.RegistrationNumber = vehicle.RegistrationNumber.ToUpper();
            vehicle.Model = vehicle.Model.ToUpper();

            var vehicleForUpdate = _mapper.Map<Vehicle>(vehicle);
            vehicleForUpdate.ModifiedDateTime = DateTime.UtcNow;
            _vehicleRepository.EditVehicle(vehicleForUpdate);
        }
        public string GetFuelTypeName(int fuelTypeId)
        {
            var name = _vehicleRepository.GetVehicleFuelTypes()
                .Where(x => x.Id == fuelTypeId && x.IsActive == true)
                .Select(p => p.Name)
                .Single();
            return name.ToString();
        }

        public string GetBrandName(int brandNameId)
        {
            VehicleBrandName vehicleBrandName = _vehicleRepository.GetVehicleBrandNames()
                                            .FirstOrDefault(x => x.Id == brandNameId && x.IsActive == true);
            if(vehicleBrandName == null)
            {
                return "";
            }

            return vehicleBrandName.Name;
        }

        public string GetTypeName(int typeId)
        {
            var name = _vehicleRepository.GetVehicleTypes()
                .Where(x => x.Id == typeId && x.IsActive == true)
                .Select(p => p.Name)
                .Single();
            return name.ToString();
        }

        public ListForUserCarsForListVm GetUserCars(string userId)
        {
            List<UserCarsForListVm> userCarsList = null;

            try
            {
                userCarsList = _vehicleRepository.GetVehicles()
                .Where(x => x.ApplicationUserID.Equals(userId) && x.IsActive == true)
                .ProjectTo<UserCarsForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            }
            catch (Exception)
            {
                return null;
            }

            if (userCarsList != null)
            {
                var userCars = new ListForUserCarsForListVm();
                userCars.UserCars = userCarsList.OrderBy(x => x.Name).ToList();
                return userCars;
            }

            return null;
        }

        public ListForUnitOfFuelForListVm GetUnitsOfFuels()
        {
            var unitsOfFuel = _vehicleRepository.GetUnitsOfFuel().ProjectTo<UnitOfFuelForListVm>(_mapper.ConfigurationProvider)
                .Where(x => x.IsActive == true)
                .ToList();

            var unitsOfFuelist = new ListForUnitOfFuelForListVm();
            unitsOfFuelist.UnitOfFuelList = unitsOfFuel;

            return unitsOfFuelist;
        }
        /// <summary>
        /// Helper method for AddRefuling
        /// </summary>
        /// <returns>Return last mileage</returns>
        public int GetLastRefuelingMileage(int vehicleId)
        {
            var refuelings = _vehicleRepository.GetAllRefuelings();

            var lastMileage = refuelings.Where(x => x.VehicleId == vehicleId)
                .OrderByDescending(x => x.CreatedDateTime)
                .Select(x => x.MeterStatus).FirstOrDefault();

            if (lastMileage == 0)
            {
                var carMilleage = _vehicleRepository.GetVehicleById(vehicleId);
                var milleage = Convert.ToInt32(carMilleage.Millage);
                return milleage;
            }
            else
            {
                return lastMileage;
            }
        }
        public bool AddEvent(NewEventVm model, NewCarHistoryVm carHistoryVm)
        {
            if (model is null)
            {
                return false;
            }
            else
            {
                var eventModelToAdd = _mapper.Map<Event>(model);

                //if 1 is "TANKOWANIE" I don't need fuel burning etc.
                if (model.EventsListId == 1)
                {
                    eventModelToAdd.BurningFuelPerOneHundredKilometers =
                        VehicleServiceHelpers.ReturnBurningPerOneHoundredKilometers(model);
                    eventModelToAdd.PriceForEvent = decimal.Multiply(eventModelToAdd.AmountOfFuel, eventModelToAdd.PriceForOneUnit);
                }
                var carHistoryModelToAdd = _mapper.Map<CarHistory>(carHistoryVm);
                eventModelToAdd.IsActive = true;
                eventModelToAdd.EventListId = model.EventsListId;
                eventModelToAdd.CreatedDateTime = DateTime.Now; ;
                eventModelToAdd.UnitOfFuelId = 1;
                eventModelToAdd.FuelForRefuelingId = 1;
                eventModelToAdd.Id = Guid.NewGuid().ToString();
                string userId = GetUserIdByVehicleId(eventModelToAdd.VehicleId);
                bool eventSucessfullyAdded = _vehicleRepository.AddEvent(eventModelToAdd, userId, carHistoryModelToAdd);
                return eventSucessfullyAdded;
            }
        }

        public ListFuelTypeForRefuelingForListVm GetFuelAllTypeForRefueling()
        {
            var fuelTypesList = _vehicleRepository.GetFuelTypesForRefueling()
                .ProjectTo<FuelTypeForRefuelingForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var listFuelTypesForRefueling = new ListFuelTypeForRefuelingForListVm()
            {
                FuelTypeForRefuelingForLists = fuelTypesList
            };

            return listFuelTypesForRefueling;
        }
        private string GetUserIdByVehicleId(int vehicleId)
        {
            var userCar = _vehicleRepository.GetVehicles()
                .FirstOrDefault(x => x.Id == vehicleId);

            return userCar.ApplicationUserID;
        }
        public List<VehicleFuelTypeVm> GetAllFuelsTypes()
        {
            var result = _vehicleRepository.GetVehicleFuelTypes()
                .ProjectTo<VehicleFuelTypeVm>(_mapper.ConfigurationProvider)
                .ToList();

            return result;
        }

        public ListCarHistoryForListVm GetUserVehicleHistory(string userId)
        {
            IQueryable<CarHistory> vehicleHistories = _vehicleRepository.GetAllVehicleHistory();
            IQueryable<Event> refuelings = _vehicleRepository.GetAllRefuelings().Where(x => x.IsActive == true);
            IQueryable<CarHistoryForListVm> result = from vh in vehicleHistories
                                                     join rf in refuelings on vh.EventRef equals rf.Id
                                                     select new CarHistoryForListVm
                                                     {
                                                         Name = vh.Name,
                                                         MeterStatus = rf.MeterStatus,
                                                         CreatedDateTime = vh.CreatedDateTime,
                                                         RefuelingPrice = rf.PriceForEvent,
                                                         ApplicationUserID = vh.ApplicationUserID,
                                                         RefulingRef = vh.EventRef,
                                                         EventDate = rf.EventDate,
                                                         VehicleId = vh.VehicleId
                                                     };
            var forRes = result.Where(x => x.ApplicationUserID.Equals(userId))
                .OrderByDescending(x => x.CreatedDateTime).ToList();

            var userVehicleHistoryVm = new ListCarHistoryForListVm()
            {
                CarHistoryList = forRes
            };

            return userVehicleHistoryVm;
        }

        public NewCarHistoryVm ReturnCarHistoryToAdd(int kindOfEventId, string userId)
        {
            string kindOfEventName = GetAllKindsOfEvents().FirstOrDefault(x => x.Id == kindOfEventId).Name;
            if (string.IsNullOrEmpty(kindOfEventName))
            {
                kindOfEventName = "Zdarzenie bez nazwy!";
            }
            var carHistoryToAdd = new NewCarHistoryVm()
            {
                Id = Guid.NewGuid().ToString(),
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                Name = kindOfEventName,
                ApplicationUserID = userId,
                CreatedById = userId
            };
            return carHistoryToAdd;
        }

        public EventDetailsVm GetRefuelById(string refuelingId)
        {
            Event refueling = _vehicleRepository.GetRefuelingById(refuelingId);
            EventDetailsVm result = _mapper.Map<EventDetailsVm>(refueling);
            if (result is null) return null;
            return result;
        }

        public string GetVehicleNameById(int vehicleId)
        {
            var vehicle = GetVehicleDetails(vehicleId);
            string vehicleName = string.Concat(vehicle.VehicleBrandName, " ", vehicle.Model, " ", vehicle.RegistrationNumber);
            if (vehicleName == null)
            {
                return "Brak danych";
            }
            return vehicleName;
        }

        public string GetUnitsOfFuelNameById(int unitOfFuelId)
        {
            string unitName = "";

            try
            {
                unitName = GetUnitsOfFuels().UnitOfFuelList.FirstOrDefault(x => x.Id == unitOfFuelId).Name;
            }
            catch (Exception)
            {
                return "Brak danych - skontaktuj się z administratorem";
            }

            if (string.IsNullOrEmpty(unitName))
            {
                return "Brak danych - skontaktuj się z administratorem";
            }
            return unitName;
        }

        public string GetFuelNameById(int fuelForRefuelingId)
        {
            string fuelName = "";
            try
            {
                fuelName = GetAllFuelsTypesForRefuling().FuelTypeForRefuelingForLists.Where(x => x.IsActive == true)
                    .FirstOrDefault(x => x.Id == fuelForRefuelingId).Name;
            }
            catch (Exception e)
            {
                return "Brak danych - skontaktuj się z administratorem";
            }
            if (string.IsNullOrEmpty(fuelName))
            {
                return "Brak danych - skontaktuj się z administratorem";
            }
            return fuelName;
        }
        public bool DeleteEvent(string eventId)
        {
            if (eventId == null) return false;

            bool isDeleteRefuel = _vehicleRepository.DeleteEvent(eventId);
            return isDeleteRefuel;
        }

        public List<KindOfEventsListVm> GetAllKindsOfEvents()
        {
            IQueryable<KindOfEvent> kindOfEventsFromDb = _vehicleRepository.GetAllKindOfEvents();

            if (kindOfEventsFromDb != null)
            {
                var result = kindOfEventsFromDb.OrderByDescending(x => x.Name).
                    ProjectTo<KindOfEventsListVm>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Name)
                    .ToList();
                return result;
            }

            return null;
        }
        public List<VehicleEventsForListVm> GetEventsBetweenTwoDates(int vehicleId, string startDay, string endDay)
        {
            List<VehicleEventsForListVm> events = new List<VehicleEventsForListVm>();

            bool isCorrectStartDay = DateTime.TryParse(startDay, out DateTime startDate);
            bool isCorrectEndDay = DateTime.TryParse(endDay, out DateTime endDate);

            if (startDay == null || endDay == null || (isCorrectEndDay || isCorrectStartDay) == false)
            {
                events = _vehicleRepository.GetAllEvents()
                  .Where(x => x.VehicleId == vehicleId)
                  .OrderBy(x => x.CreatedDateTime)
                  .ProjectTo<VehicleEventsForListVm>(_mapper.ConfigurationProvider)
                  .ToList();
                return events;
            }
            else
            {
                events = _vehicleRepository.GetAllEvents()
                   .Where(x => x.VehicleId == vehicleId)
                   .Where(x => x.EventDate >= startDate && x.EventDate <= endDate)
                   .OrderBy(x => x.CreatedDateTime)
                   .ProjectTo<VehicleEventsForListVm>(_mapper.ConfigurationProvider)
                   .ToList();
                return events;
            }
        }
        public VehicleStatsVm GetVehicleStats(int vehicleId, string startDay, string endDay)
        {
            List<VehicleEventsForListVm> events = GetEventsBetweenTwoDates(vehicleId, startDay, endDay);

            VehicleStatsVm vehicleStats = new VehicleStatsVm();
            if (events.Count > 0)
            {
                vehicleStats.AverageFuelBurningForChart = VehicleServiceHelpers.ReturnAvgBurningForChart(events);
                vehicleStats.KilometersForChart = VehicleServiceHelpers.ReturnKilometersForChart(events);
                vehicleStats.Kilometers = events.Max(x => x.MeterStatus);
                vehicleStats.TotalCostForEvents = events.Sum(x => x.PriceForEvent);
                vehicleStats.TheBiggestPriceForEvent = events.Max(x => x.PriceForEvent);
                vehicleStats.TheSmallestPriceForEvent = events.Min(x => x.PriceForEvent);
                vehicleStats.AverageFuelBurning = VehicleServiceHelpers.ReturnBurningPerOneHoundredKilometers(events);
                vehicleStats.TheBiggestFuelBurning = events.Max(x => x.BurningFuelPerOneHundredKilometers);
                vehicleStats.TheSmallestFuelBurning = events.Min(x => x.BurningFuelPerOneHundredKilometers);
            }
            return vehicleStats;
        }

    }
}