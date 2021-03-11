using AutoMapper;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class KindOfEventsListVm : IMapFrom<KindOfEvent>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KindOfEvent, KindOfEventsListVm>();
        }
    }
}