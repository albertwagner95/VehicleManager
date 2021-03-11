using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class VehicleStatsVm //: IMapFrom<Domain.Model.VehicleModels.Vehicle>
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int Kilometers { get; set; }
        public decimal AverageFuelBurning { get; set; }
        public decimal TotalCostForEvents { get; set; }
        public decimal TheBiggestPriceForEvent { get; set; }
        public decimal TheSmallestPriceForEvent { get; set; }
        public decimal TheBiggestFuelBurning { get; set; }
        public decimal TheSmallestFuelBurning { get; set; }
        public string AverageFuelBurningForChart { get; set; }
        public string KilometersForChart { get; set; }
        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<VehicleStatsVm, Domain.Model.VehicleModels.Vehicle>().ReverseMap()
        //                    .ForMember(s => s.VehicleName, opt => opt.MapFrom(x => string.Concat("Pojazd ", x.VehicleBrandName.Name, " ", x.RegistrationNumber, " ")));
        //}
    }
}
