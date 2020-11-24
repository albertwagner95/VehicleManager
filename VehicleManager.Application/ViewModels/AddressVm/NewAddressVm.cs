using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class NewAddressVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} jest wymagane")]
        public string Voivodeship { get; set; }
        [RegularExpression(@"^(?!0*(\.0+)?$)(\d+|\d*\.\d+)$", ErrorMessage = "Proszę uzupełnij pole")]
        public string District { get; set; }
        [RegularExpression(@"^(?!0*(\.0+)?$)(\d+|\d*\.\d+)$", ErrorMessage = "Proszę uzupełnij pole")]
        public string City { get; set; }
        [RegularExpression(@"^(?!0*(\.0+)?$)(\d+|\d*\.\d+)$", ErrorMessage = "Proszę uzupełnij pole")]
        public string Community { get; set; }
        [RegularExpression(@"^(?!0*(\.0+)?$)(\d+|\d*\.\d+)$", ErrorMessage = "Proszę uzupełnij pole")]
        public string CityType { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wartość wymagana")]
        public string BuildigNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wartość wymagana")]
        public int FlatNumber { get; set; }
        public string StreetFromUser { get; set; }
        public int AddressTypeId { get; set; }
        public IEnumerable<VoivodeshipVm> VoivodeshipsVm { get; set; }
        public List<AddressTypeForListVm> AddressTypes { get; set; }
        public string ApplicationUserID { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAddressVm, Address>().ReverseMap();
        }
    }

}

