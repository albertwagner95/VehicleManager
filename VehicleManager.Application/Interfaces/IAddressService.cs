using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Domain.Model.AddressModels;

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
        int AddNewAddress();
    }
}
