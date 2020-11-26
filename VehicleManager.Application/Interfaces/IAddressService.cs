using System.Collections.Generic;
using VehicleManager.Application.ViewModels.AddressVm;

namespace VehicleManager.Application.Interfaces
{
    public interface IAddressService
    {
        List<VoivodeshipVm> GetAllVoivedoships();
        // List<DistrictVm> GetAllDistricts(string name);
        List<DistrictVm> GetDistrictsByVoivedoship(string voivodeshipId);
        IEnumerable<CityVm> GetCitiesByCommunityId(string districtId);
        List<CommunityVm> GetCommunitiesByDistricId(string districtId);
        CityTypeVm GetCityType(string cityId);
        List<AddressTypeForListVm> GetAddressTypes();
        string GetVoivedoshipNameById(string id);
        string GetCommunityNameById(string id);
        string GetCityTypeById(string id);
        string GetDistrictNameById(string id);
        string GetCityNameById(int id);
        int AddNewAddress(NewAddressVm newAddressVm);
        void DeleteAddress(int addressId);
        NewAddressVm GetAddressById(int id);
    }
}
