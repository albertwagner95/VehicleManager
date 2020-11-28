using System;
using System.Collections.Generic;
using VehicleManager.Domain.Common;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Domain.Model
{
    public class Vehicle : AuditableModel
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public int? Millage { get; set; }
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


        //public int CountryRef { get; set; }
        //public virtual Country Country { get; set; }
        //dodac country 1-1
        //public int VehicleServiceId { get; set; }
        //public virtual VehicleService VehicleService { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int VehicleBrandNameId { get; set; }
        public virtual VehicleBrandName VehicleBrandName { get; set; }
        public int VehicleFuelTypeId { get; set; }
        public virtual VehicleFuelType VehicleFuelType { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public ICollection<Refuling> Refulings { get; set; }

        public string CarHistoryId { get; set; }
        public virtual CarHistory CarHistory { get; set; }
    }
}
