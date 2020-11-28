using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model.AddressModels;
using Xunit;

namespace VehicleManager.Tests.Services
{
    public class AddressServiceTests
    {

        [Fact]
        public void ShouleReturnDistrictsForVoivedoship()
        {
            //Arrange
            var mapper = new Mock<IMapper>();

            var cities = new List<City>();
            cities.Add(new City() { Id = 1, Name = "Lublin", DistrictId = "1", VoivodeshipId = "1" });
            cities.Add(new City() { Id = 2, Name = "Wilkolaz", DistrictId = "2", VoivodeshipId = "1" });
            cities.Add(new City() { Id = 3, Name = "Rzeszów", DistrictId = "3", VoivodeshipId = "2" });
            var districts = new List<District>();
            districts.Add(new District() { Id = "1", Name = "Lublin", Cities = cities });
            districts.Add(new District() { Id = "2", Name = "Kraśnicki", Cities = cities });
            districts.Add(new District() { Id = "3", Name = "Rzeszów", Cities = cities });
            var voivedoships = new List<Voivodeship>();
            voivedoships.Add(new Voivodeship() { Id = "1", Name = "Lubelskie", Cities = cities });
            voivedoships.Add(new Voivodeship() { Id = "2", Name = "Podkarpackie", Cities = cities });
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetAllDistricts()).Returns(districts.AsQueryable());
            addressRepository.Setup(x => x.GetAllCities()).Returns(cities.AsQueryable());
            addressRepository.Setup(x => x.GetAllVoivedoships()).Returns(voivedoships.AsQueryable());

            var addressService = new AddressService(addressRepository.Object, mapper.Object);

            //Act
            var result = addressService.GetDistrictsByVoivedoship("1");
            var resultTwo = addressService.GetDistrictsByVoivedoship("2");
            var resultThree = addressService.GetDistrictsByVoivedoship("3");

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().NotBeNullOrEmpty();
            result.Should().OnlyHaveUniqueItems();
            result.Should().BeInDescendingOrder(a => a.Name);
            result[0].Name.Should().Equals("Kraśnicki");

            resultTwo.Should().NotBeNull();
            resultTwo.Should().HaveCount(1);
            resultTwo.Should().NotBeNullOrEmpty();
            resultTwo.Should().OnlyHaveUniqueItems();
            resultTwo.Should().BeInDescendingOrder(a => a.Name);
            resultTwo[0].Name.Should().Equals("Rzeszów");

            resultThree.Should().BeEmpty();
            resultThree.Should().HaveCount(0);
        }
        [Fact]
        public void ShouleReturnCommunitiesForDistricts()
        {
            //Arrange
            var mapper = new Mock<IMapper>();

            var cities = new List<City>();
            cities.Add(new City() { Id = 1, Name = "Lublin", DistrictId = "1", CommunityId = "1" });
            cities.Add(new City() { Id = 2, Name = "Wilkolaz", DistrictId = "1", CommunityId = "2" });
            cities.Add(new City() { Id = 3, Name = "Rzeszów", DistrictId = "3", CommunityId = "2" });
            var districts = new List<District>();
            districts.Add(new District() { Id = "1", Name = "Lublin", Cities = cities });
            districts.Add(new District() { Id = "2", Name = "Kraśnicki", Cities = cities });
            districts.Add(new District() { Id = "3", Name = "Rzeszów", Cities = cities });
            var communities = new List<Community>();
            communities.Add(new Community() { Id = "1", Name = "Gmina Lublin", Cities = cities });
            communities.Add(new Community() { Id = "2", Name = "Gmina Rzeszów", Cities = cities });
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetAllDistricts()).Returns(districts.AsQueryable());
            addressRepository.Setup(x => x.GetAllCities()).Returns(cities.AsQueryable());
            addressRepository.Setup(x => x.GetAllCommunities()).Returns(communities.AsQueryable());

            var addressService = new AddressService(addressRepository.Object, mapper.Object);

            //Act
            var result = addressService.GetCommunitiesByDistricId("1");
            var resultTwo = addressService.GetCommunitiesByDistricId("2");

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().NotBeNullOrEmpty();
            result.Should().OnlyHaveUniqueItems();
            result.Should().BeInDescendingOrder(a => a.Name);
            result[0].Name.Should().Equals("Gmina Lublin");

            resultTwo.Should().BeEmpty();
            resultTwo.Should().HaveCount(0);
        }
            [Fact]
        public void ShouldReturnVoivedoshipName()
        {
            //Arrange
            var voivList = new List<Voivodeship>();
            voivList.Add(new Voivodeship() { Id = "1", Name = "Lubelskie", Cities = null });
            voivList.Add(new Voivodeship() { Id = "2", Name = "Podkarpackie", Cities = null });
            var mapper = new Mock<IMapper>();
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetAllVoivedoships()).Returns(voivList.AsQueryable());
            var addressService = new AddressService(addressRepository.Object, mapper.Object);
            //Act
            var result = addressService.GetVoivedoshipNameById("1");
            var resTwo = addressService.GetVoivedoshipNameById("12");

            //Assert
            result.Should().Be("Lubelskie");
            result.Should().NotBeNull();
            result.Should().HaveLength(9);
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBeNullOrEmpty();

            resTwo.Should().BeNullOrWhiteSpace();
            resTwo.Should().BeNullOrEmpty();
            resTwo.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnCommunityName()
        {
            //Arrange
            var voivList = new List<Community>();
            voivList.Add(new Community() { Id = "1", Name = "Lublin", Cities = null });
            voivList.Add(new Community() { Id = "2", Name = "Wilkołaz", Cities = null });
            var mapper = new Mock<IMapper>();
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetAllCommunities()).Returns(voivList.AsQueryable());
            var addressService = new AddressService(addressRepository.Object, mapper.Object);
            //Act
            var result = addressService.GetCommunityNameById("1");
            var resTwo = addressService.GetCommunityNameById("12");

            //Assert
            result.Should().Be("Lublin");
            result.Should().NotBeNull();
            result.Should().HaveLength(6);
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBeNullOrEmpty();

            resTwo.Should().BeNullOrWhiteSpace();
            resTwo.Should().BeNullOrEmpty();
            resTwo.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnCityTypeName()
        {
            //Arrange
            var voivList = new List<CityType>();
            voivList.Add(new CityType() { Id = "1", Name = "Wieś", Cities = null });
            voivList.Add(new CityType() { Id = "2", Name = "Miasto", Cities = null });
            var mapper = new Mock<IMapper>();
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetCityTypes()).Returns(voivList.AsQueryable());
            var addressService = new AddressService(addressRepository.Object, mapper.Object);
            //Act
            var result = addressService.GetCityTypeById("1");
            var resTwo = addressService.GetCityTypeById("12");

            //Assert
            result.Should().Be("Wieś");
            result.Should().NotBeNull();
            result.Should().HaveLength(4);
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBeNullOrEmpty();

            resTwo.Should().BeNullOrWhiteSpace();
            resTwo.Should().BeNullOrEmpty();
            resTwo.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnDistrictName()
        {
            //Arrange
            var voivList = new List<District>();
            voivList.Add(new District() { Id = "1", Name = "Kraśnicki", Cities = null });
            voivList.Add(new District() { Id = "2", Name = "Lublin", Cities = null });
            var mapper = new Mock<IMapper>();
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetAllDistricts()).Returns(voivList.AsQueryable());
            var addressService = new AddressService(addressRepository.Object, mapper.Object);
            //Act
            var result = addressService.GetDistrictNameById("1");
            var resTwo = addressService.GetDistrictNameById("12");

            //Assert
            result.Should().Be("Kraśnicki");
            result.Should().NotBeNull();
            result.Should().HaveLength(9);
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBeNullOrEmpty();

            resTwo.Should().BeNullOrWhiteSpace();
            resTwo.Should().BeNullOrEmpty();
            resTwo.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnCityName()
        {
            //Arrange
            var voivList = new List<City>();
            voivList.Add(new City() { Id = 1, Name = "Warszawa" });
            voivList.Add(new City() { Id = 1, Name = "Lublin" });
            var mapper = new Mock<IMapper>();
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(x => x.GetAllCities()).Returns(voivList.AsQueryable());
            var addressService = new AddressService(addressRepository.Object, mapper.Object);
            //Act
            var result = addressService.GetCityNameById(1);
            var resTwo = addressService.GetCityNameById(12);

            //Assert
            result.Should().Be("Warszawa");
            result.Should().NotBeNull();
            result.Should().HaveLength(8);
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBeNullOrEmpty();

            resTwo.Should().BeNullOrWhiteSpace();
            resTwo.Should().BeNullOrEmpty();
            resTwo.Should().BeNull();
        }
    }
}
