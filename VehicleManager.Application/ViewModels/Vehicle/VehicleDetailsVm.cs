using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class VehicleDetailsVm :IMapFrom<Domain.Model.Vehicle>
    {
        public int Id { get; set; }
        [MaxLength(17)]
        public string Vin { get; set; }
        public int Millage { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfFirstRegistration { get; set; }
        public string Model { get; set; }
        public bool IsRegisterdInPoland { get; set; }
        [MaxLength(8)]
        public string RegistrationNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProductionDate { get; set; }
        public int EnginePower { get; set; } //kw
        public int EngineCapacity { get; set; }
        public int PermissibleGrossWeight { get; set; }
        public int Capacity { get; set; }
        public int OwnWeight { get; set; }
        public int YearHelper { get; set; }
        public string ApplicationUserID { get; set; }
        public int VehicleFuelTypeId { get; set; }
        public int VehicleBrandNameId { get; set; }
        public int VehicleTypeId { get; set; }
        public List<VehicleFuelTypeVm> VehicleFuelTypes { get; set; }
        public List<VehicleBrandNameVm> VehicleBrandNames { get; set; }
        public List<VehicleTypeVm> VehicleTypes { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<VehicleDetailsVm, Domain.Model.Vehicle>().ReverseMap();
        }
    }
}
