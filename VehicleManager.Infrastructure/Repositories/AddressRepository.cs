using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly Context _context;
        public AddressRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<BaseAddress> GetAllAddresses()
        {
            var addresses = _context.BaseAddress;
            return addresses;
        }

        public IQueryable<string> GetAllCommunities()
        {
            throw new NotImplementedException();
        }
        public IQueryable<string> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Voivodeship> GetAllVoivedoships()
        {
            var voivedoshipList = _context.Voivodeships
                                .OrderBy(vs => vs);
            return voivedoshipList;
        }

        public IQueryable<City> GetAllCities()
        {
            var cities = _context.Cities;
            return cities;
        }

        public IQueryable<District> GetAllDistricts()
        {
            var districts = _context.Districts;
            return districts;
        }
        public IQueryable<City> GetCitiesByCommunityId(string communityId)
        {
            var cities = _context.Cities
                        .Where(x => x.CommunityId.Equals(communityId))
                        .OrderBy(a => a.Name);

            return cities;
        }

        IQueryable<Community> IAddressRepository.GetAllCommunities()
        {
            var communities = _context.Communities;
            return communities;
        }

        public IQueryable<CityType> GetCityTypes()
        {
            var cityTypes = _context.CityTypes;
            return cityTypes;
        }

        public IQueryable<AddressType> GetAddressTypes()
        {
            var addressTypes = _context.AddressTypes;
            return addressTypes;
        }

        //public string GetVoivedoshipNameById(string id)
        //{
        //    var voivName = _context.Voivodeships.FirstOrDefault(x => x.Id.Equals(id));
        //    return voivName.Name;
        //}

        //public string GetCommunityNameById(string id)
        //{
        //    var communityName = _context.Communities.FirstOrDefault(x => x.Id.Equals(id));
        //    return communityName.Name;
        //}

        //public string GetCityTypeById(string id)
        //{
        //    var cityTypeName = _context.CityTypes.FirstOrDefault(x => x.Id.Equals(id));
        //    return cityTypeName.Name;
        //}

        //public string GetDistrictNameById(string id)
        //{
        //    var districtName = _context.Districts.FirstOrDefault(x => x.Id.Equals(id));
        //    return districtName.Name;
        //}

        //public string GetCityNameById(int id)
        //{
        //    var cityName = _context.Cities.FirstOrDefault(x => x.Id.Equals(id));
        //    return cityName.Name;
        //}

        public int AddNewAddress()
        {
            throw new NotImplementedException();
        }
    }
}
