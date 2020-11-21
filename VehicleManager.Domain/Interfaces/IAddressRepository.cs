using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Domain.Interfaces
{
    public interface IAddressRepository
    {
        IQueryable<BaseAddress> GetAllAddresses();
        IQueryable<Voivodeship> GetAllVoivedoships();
        IQueryable<City> GetAllCities();
        IQueryable<District> GetAllDistricts();
        IQueryable<Community> GetAllCommunities();
        IQueryable<City> GetCitiesByCommunityId(string districtId);
        IQueryable<CityType> GetCityTypes();
    }
}
