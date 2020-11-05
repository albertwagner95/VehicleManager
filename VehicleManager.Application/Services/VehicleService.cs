using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels;
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

            var vehicl = _mapper.Map<Domain.Model.Vehicle>(vehicle);
            vehicl.CreatedDateTime = DateTime.Now;
            vehicl.CreatedById = "userid";

            _vehicleRepository.AddVehicle(vehicl);
            return vehicl.Id;
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
    }
}
