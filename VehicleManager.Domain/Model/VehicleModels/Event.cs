using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model.VehicleModels
{
    public class Event : AuditableModel
    {
        public string Id { get; set; }
        public decimal AmountOfFuel { get; set; }
        public decimal PriceForEvent { get; set; }
        public decimal PriceForOneUnit { get; set; }
        public int MeterStatus { get; set; }
        public string PetrolStationName { get; set; } //optional
        public bool IsRefulingFull { get; set; }
        public string Varnings { get; set; }
        public int VehicleId { get; set; }
        public decimal BurningFuelPerOneHundredKilometers { get; set; }
        public DateTime EventDate { get; set; }
        public CarHistory CarHistory { get; set; }
        public int UnitOfFuelId { get; set; }
        public virtual UnitOfFuel UnitOfFuel { get; set; }
        public int FuelForRefuelingId { get; set; }
        public virtual FuelForRefueling FuelForRefueling { get; set; }
        public int EventListId { get; set; }
        public virtual KindOfEvent EventList { get; set; }
    }
}
