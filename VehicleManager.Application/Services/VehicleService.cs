using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;

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
            var result =_vehicleRepository.AddVehicle(vehicl);
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

        public IQueryable<VehicleFuelTypeVm> GetAllFuelsTypes()
        {
            var vehicleFuelTypesVm = _vehicleRepository.GetVehicleFuelTypes().ProjectTo<VehicleFuelTypeVm>(_mapper.ConfigurationProvider);

            return vehicleFuelTypesVm;
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
         
    }
}
