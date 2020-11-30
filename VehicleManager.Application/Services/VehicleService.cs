using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Interfaces;
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
            vehicle.Capacity = vehicle.PermissibleGrossWeight - vehicle.OwnWeight;
            vehicle.ProductionDate = new DateTime(vehicle.YearHelper, 1, 1);
            vehicle.Vin = vehicle.Vin.ToUpper();
            vehicle.RegistrationNumber = vehicle.RegistrationNumber.ToUpper();
            vehicle.Model = vehicle.Model.ToUpper();
            var vehicl = _mapper.Map<Domain.Model.Vehicle>(vehicle);
            vehicl.CreatedDateTime = DateTime.Now;
            vehicl.CreatedById = "userid";
            vehicl.IsActive = true;
            var result = _vehicleRepository.AddVehicle(vehicl);
            return result; // result = 0 is false
        }

        public VehicleDetailsVm GetVehicleDetails(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);

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
        public IQueryable<VehicleBrandNameVm> GetAllBrandNames()
        {
            var vehicleBrandNames = _vehicleRepository.GetVehicleBrandNames().ProjectTo<VehicleBrandNameVm>(_mapper.ConfigurationProvider);
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
                var vehicl = _mapper.Map<Domain.Model.Vehicle>(vehicle);
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
                .Where(x => x.Id == fuelTypeId)
                .Select(p => p.Name)
                .Single();
            return name.ToString();
        }

        public string GetBrandName(int brandNameId)
        {
            var name = _vehicleRepository.GetVehicleBrandNames()
                .Where(x => x.Id == brandNameId)
                .Select(p => p.Name)
                .Single();
            return name.ToString();
        }

        public string GetTypeName(int typeId)
        {
            var name = _vehicleRepository.GetVehicleTypes()
                .Where(x => x.Id == typeId)
                .Select(p => p.Name)
                .Single();
            return name.ToString();
        }

        public ListForUserCarsForListVm GetUserCars(string userId)
        {
            var userCarsList = _vehicleRepository.GetVehicles()
                .Where(x => x.ApplicationUserID.Equals(userId) && x.IsActive == true).ProjectTo<UserCarsForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            var userCars = new ListForUserCarsForListVm();
            userCars.UserCars = userCarsList;

            return userCars;
        }

        public ListForUnitOfFuelForListVm GetUnitsOfFuels()
        {
            var unitsOfFuel = _vehicleRepository.GetUnitsOfFuel().ProjectTo<UnitOfFuelForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var unitsOfFuelist = new ListForUnitOfFuelForListVm();
            unitsOfFuelist.UnitOfFuelList = unitsOfFuel;

            return unitsOfFuelist;
        }

        public bool AddRefuling(NewRefulingVm model, NewCarHistoryVm carHistoryVm)
        {
            if (model is null)
            {
                return false;
            }
            else
            {
                var refuelingModelToAdd = _mapper.Map<Refueling>(model);
                var carHistoryModelToAdd = _mapper.Map<CarHistory>(carHistoryVm);
                refuelingModelToAdd.IsActive = true;
                string userId = GetUserIdByVehicleId(refuelingModelToAdd.VehicleId);
                bool refuelingSucessfullyAdded = _vehicleRepository.AddRefueling(refuelingModelToAdd, userId, carHistoryModelToAdd);
                if (refuelingSucessfullyAdded == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            var userVehicleHistory = _vehicleRepository.GetAllVehicleHistory()
                .Where(x => x.ApplicationUserID.Equals(userId))
                .OrderBy(x => x.CreatedDateTime)
                .ProjectTo<CarHistoryForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            var userVehicleHistoryVm = new ListCarHistoryForListVm()
            {
                CarHistoryList = userVehicleHistory
            };
            return userVehicleHistoryVm;
        }

        public NewCarHistoryVm ReturnCarHistoryToAdd(string kindOfEvent, string userId)
        {
            var carHistoryToAdd = new NewCarHistoryVm()
            {
                Id = Guid.NewGuid().ToString(),
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                Name = "Tankowanie",
                ApplicationUserID = userId,
                CreatedById = userId
            };
            return carHistoryToAdd;
        }
    }
}
