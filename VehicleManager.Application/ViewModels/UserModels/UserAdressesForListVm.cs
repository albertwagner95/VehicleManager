using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.UserModels
{
    public class UserAdressesForListVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string KindOfAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, UserAdressesForListVm>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => string.Concat("Województwo: "
                , x.Voivodeship
                , "\n"
                , "Powiat: ", x.District, "\n"
                , "Gmina: ", x.Community, "\n"
                , x.CityType, ",", x.City
                , "\nUlica: ", x.StreetFromUser, ",", x.FlatNumber, "/", x.BuildigNumber
                ))).ForMember(s=>s.KindOfAddress, opt=>opt.MapFrom(x=>x.AddressType.Name));
        }
    }
}
