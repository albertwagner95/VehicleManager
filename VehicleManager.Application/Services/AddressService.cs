using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public List<DistrictVm> GetDistrictsByVoivedoship(string voivodeshipId)
        {
            var districts = _addressRepository.GetAllDistricts();
            var cities = _addressRepository.GetAllCities();
            var voivodesships = _addressRepository.GetAllVoivedoships();

            var districtsVm = (from ds in districts
                               join ct in cities on ds.Id equals ct.DistrictId
                               join vs in voivodesships on ct.VoivodeshipId equals vs.Id
                               where vs.Id == voivodeshipId
                               select new DistrictVm
                               {
                                   Id = ds.Id,
                                   Name = ds.Name,
                               });
            var result = districtsVm.Distinct().OrderByDescending(a => a.Name).ToList();

            return result;
        }

        public List<CommunityVm> GetCommunitiesByDistricId(string districtId)
        {
            var districts = _addressRepository.GetAllDistricts();
            var cities = _addressRepository.GetAllCities();
            var communities = _addressRepository.GetAllCommunities();

            var communitiesList = (from ds in communities
                                   join ct in cities on ds.Id equals ct.CommunityId
                                   join vs in districts on ct.DistrictId equals vs.Id
                                   where vs.Id == districtId
                                   select new CommunityVm
                                   {
                                       Id = ds.Id,
                                       Name = ds.Name,
                                   });
            var result = communitiesList.Distinct().OrderByDescending(a => a.Name).ToList();
            return result;
        }

        public IEnumerable<CityVm> GetCitiesByCommunityId(string communityId)
        {
            var cities = _addressRepository.GetCitiesByCommunityId(communityId);
            if (cities != null)
            {
                return cities.ProjectTo<CityVm>(_mapper.ConfigurationProvider);
            }

            return null;
        }

        public List<VoivodeshipVm> GetAllVoivedoships()
        {
            var voivedoships = _addressRepository.GetAllVoivedoships()
                                .ProjectTo<VoivodeshipVm>(_mapper.ConfigurationProvider).ToList();

            return voivedoships;
        }

        public CityTypeVm GetCityType(string cityId)
        {
            var cityTypes = _addressRepository.GetCityTypes();
            var cities = _addressRepository.GetAllCities();
            var isConvert = int.TryParse(cityId, out int id);

            if (isConvert == true)
            {
                var cityType = (from ctp in cityTypes
                                join cts in cities on ctp.Id equals cts.CityTypeId
                                where cts.Id == id
                                select new CityTypeVm
                                {
                                    Id = ctp.Id,
                                    Name = ctp.Name,
                                }).SingleOrDefault();
                return cityType;
            }
            else
            {
                return null;
            }
        }

        public List<AddressTypeForListVm> GetAddressTypes()
        {
            var types = _addressRepository.GetAddressTypes()
                .ProjectTo<AddressTypeForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            return types;
        }

        public string GetVoivedoshipNameById(string id)
        {
            var voivodeship = _addressRepository.GetAllVoivedoships()
                .FirstOrDefault(x => x.Id.Equals(id));

            if (voivodeship == null)
            {
                return null;
            }
            else
            {
                return voivodeship.Name;
            }
        }

        public string GetCommunityNameById(string id)
        {
            var community = _addressRepository.GetAllCommunities()
                .FirstOrDefault(x => x.Id.Equals(id));

            if (community == null)
            {
                return null;
            }
            else
            {
                return community.Name;
            }
        }

        public string GetCityTypeById(string id)
        {
            var cityType = _addressRepository.GetCityTypes()
                .FirstOrDefault(x => x.Id.Equals(id));
            if (cityType == null)
            {
                return null;
            }
            else
            {
                return cityType.Name;
            }
        }

        public string GetDistrictNameById(string id)
        {
            var district = _addressRepository.GetAllDistricts()
                .FirstOrDefault(x => x.Id.Equals(id));
            if (district == null)
            {
                return null;
            }
            else
            {
                return district.Name;
            }
        }

        public string GetCityNameById(int id)
        {
            var city = _addressRepository.GetAllCities()
                           .FirstOrDefault(x => x.Id == id);
            if (city == null)
            {
                return null;
            }
            else
            {
                return city.Name;
            }
        }

        public int AddNewAddress(NewAddressVm newAddressVm)
        {
            newAddressVm.Voivodeship = GetVoivedoshipNameById(newAddressVm.Voivodeship);
            var isId = int.TryParse(newAddressVm.City, out int cityId);
            if (isId == true)
            {
                newAddressVm.City = GetCityNameById(cityId);
            }
            else
            {
                newAddressVm.City = "City name is inccorrect";
            }
            newAddressVm.CityType = GetCityTypeById(newAddressVm.CityType);
            newAddressVm.Community = GetCommunityNameById(newAddressVm.Community);
            newAddressVm.District = GetDistrictNameById(newAddressVm.District);

            var newAddress = _mapper.Map<Address>(newAddressVm);
            newAddress.CreatedDateTime = DateTime.Now;
            newAddress.IsActive = true;
            var isSuccesAddNewAddress = _addressRepository.AddNewAddress(newAddress);
            return isSuccesAddNewAddress;
        }

        public void DeleteAddress(int addressId)
        {
            var address = _addressRepository.GetAddressById(addressId);
            _addressRepository.DeleteAddress(address);
        }

        public NewAddressVm GetAddressById(int id)
        {
            var address = _addressRepository.GetAddressById(id);
            var result = _mapper.Map<NewAddressVm>(address);
            return result;
        }
    }
}
