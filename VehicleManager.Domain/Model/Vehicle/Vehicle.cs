using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class Vehicle : AuditableModel
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public int Millage { get; set; }
        public DateTime DateOfFirstRegistration { get; set; }
        public bool IsRegisterdInPoland { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public int WayOfUsageId { get; set; }
        public int OwnerId { get; set; }

        public int VehicleBrandRef { get; set; }
        public virtual VehicleBrand VehicleBrand { get; set; }
        public int VehicleModelRef { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public int VehicleTypeRef { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int KindOfFuelRef { get; set; }
        public virtual KindOfFuel KindOfFuel { get; set; }
        public int VehicleServiceId { get; set; }
        public virtual VehicleService VehicleService { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int CarHistoryId { get; set; }
        public virtual CarHistory CarHistory { get; set; }

        public int VehicleOwnerId { get; set; }
        public virtual VehicleOwner VehicleOwner { get; set; }
        public int VehicleUserId { get; set; }
        public virtual VehicleUser VehicleUser { get; set; }
    }
}
