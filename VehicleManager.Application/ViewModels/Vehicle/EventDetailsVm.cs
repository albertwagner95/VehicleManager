using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class EventDetailsVm : IMapFrom<Event>
    {
        public string Id { get; set; }
        public decimal AmountOfFuel { get; set; }
        public decimal FuelPrice { get; set; }
        public decimal PriceForOneUnit { get; set; }
        public int MeterStatus { get; set; }
        public string PetrolStationName { get; set; } //optional
        public bool IsRefulingFull { get; set; }
        public string Varnings { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string BurningFuelPerOneHundredKilometers { get; set; }
        public int UnitOfFuelId { get; set; }
        public string UnitOfFuelName { get; set; }
        public int FuelForRefuelingId { get; set; }
        public string FuelName { get; set; }
        public string CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventDetailsVm>()
                .ForMember(s => s.CreateDate, opt => opt.MapFrom(x => x.CreatedDateTime.Value.ToShortDateString()))
                .ForMember(s => s.BurningFuelPerOneHundredKilometers, opt => opt.MapFrom(x => string.Concat(x.BurningFuelPerOneHundredKilometers, " 100/km")));
        }
    }
}