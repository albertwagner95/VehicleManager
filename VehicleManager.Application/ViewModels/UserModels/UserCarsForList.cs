using AutoMapper;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.UserModels
{
    public class UserCarsForList : IMapFrom<Domain.Model.Vehicle>
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Vehicle, UserCarsForList>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => string.Concat(x.VehicleBrandName.Name, " ", x.Model)));
        }
    }

}