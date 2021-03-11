using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class VehicleEventsForListVm: IMapFrom<Event>
    {
        public int VehicleId { get; set; }
        public int EventListId { get; set; }

        public int MeterStatus { get; set; }
        public decimal BurningFuelPerOneHundredKilometers { get; set; }
        public decimal AmountOfFuel { get; set; }
        public decimal PriceForEvent { get; set; }
        public DateTime EventDate { get; set; }

        //public decimal MaxFuelBurninng { get; set; }
        //public decimal MinFuelBurninng { get; set; }
        //public decimal EventsCost { get; set; }
        //public decimal FuelCost { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VehicleEventsForListVm, Event>().ReverseMap();
        }

    }
}
