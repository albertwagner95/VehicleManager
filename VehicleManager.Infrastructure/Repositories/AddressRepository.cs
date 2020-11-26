using System.Linq;
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

        public IQueryable<Community> GetAllCommunities()
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
        public int AddNewAddress(Address address)
        {
            if (address != null)
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();

                return address.Id;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteAddress(Address address)
        {
            address.IsActive = false;
            _context.Attach(address);
            _context.Entry(address).Property("IsActive").IsModified = true;
            _context.SaveChanges();
            return address.Id;
        }

        public Address GetAddressById(int addressId)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == addressId);
            return address;
        }
    }
}
