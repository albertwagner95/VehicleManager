using AutoMapper;
using System;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class VehicleDetailsVm : IMapFrom<Domain.Model.Vehicle>
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public int Millage { get; set; }
        public DateTime DateOfFirstRegistration { get; set; }
        public string Model { get; set; }
        public bool IsRegisterdInPoland { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public int EnginePower { get; set; } //kw
        public int EngineCapacity { get; set; }
        public int PermissibleGrossWeight { get; set; }
        public int Capacity { get; set; }
        public int OwnWeight { get; set; }
        public bool IsGasInstalation { get; set; }

        public string ProductionDateString { get; set; }
        public string DataOfFirstRegistrationString { get; set; }
        public string VehicleFuelTypeName { get; set; }
        public string VehicleBrandName { get; set; }
        public string VehicleTypeName { get; set; }

        public int VehicleFuelTypeId { get; set; }
        public int VehicleBrandNameId { get; set; }
        public int VehicleTypeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<VehicleDetailsVm, Domain.Model.Vehicle>().ReverseMap();
        }
    }
}
