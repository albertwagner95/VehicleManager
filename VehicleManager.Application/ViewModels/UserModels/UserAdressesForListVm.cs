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
        public string KindOfAddress { get; set; }
        public string CityAndType { get; set; }
        public string StreetAndBuildNumber { get; set; }
        public string Voivedoshipha { get; set; }
        public string Districts { get; set; }
        public string ZipCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, UserAdressesForListVm>()
                .ForMember(s => s.CityAndType, opt => opt.MapFrom(x => string.Concat(x.CityType, " ", x.City, ",")))
                .ForMember(s => s.StreetAndBuildNumber, opt => opt.MapFrom(x => string.Concat("ul. ", x.StreetFromUser, " ", x.BuildigNumber, "/", x.FlatNumber, ",")))
                .ForMember(s => s.Voivedoshipha, opt => opt.MapFrom(x => string.Concat("Województwo: ", x.Voivodeship, ",")))
                .ForMember(s => s.Districts, opt => opt.MapFrom(x => string.Concat("Powiat: ", x.District, ",")))
                .ForMember(s => s.KindOfAddress, opt => opt.MapFrom(x => x.AddressType.Name));
        }
    }
}
