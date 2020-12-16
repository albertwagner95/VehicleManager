using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Mapping;
using VehicleManager.Application.Services;
using VehicleManager.Application.ViewModels;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;
using Xunit;
using VehicleService = VehicleManager.Application.Services.VehicleService;

namespace VehicleManager.Tests.Services
{
    public class VehicleServiceTests
    {
        [Fact]
        public void ShouldReturnBrandName()
        {
            //Arrange
            var ford = new VehicleBrandName() { Id = 1, Name = "Ford", IsActive = true };
            var opel = new VehicleBrandName() { Id = 2, Name = "Opel", IsActive = true };
            var vehicleBrands = new List<VehicleBrandName>();
            vehicleBrands.Add(ford);
            vehicleBrands.Add(opel);
            var mapper = new Mock<IMapper>();
            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(x => x.GetVehicleBrandNames()).Returns(vehicleBrands.AsQueryable());
            var vehicleService = new VehicleService(vehicleRepository.Object, mapper.Object);

            var result = vehicleService.GetBrandName(1);
            var secondResult = vehicleService.GetBrandName(2);

            result.Should().Be("Ford");
            secondResult.Should().Be("Opel");
        }
        [Fact]
        public void ShouldReturnCarHistory()
        {
            //Arrange
            var listVehicleHistories = new List<CarHistory>();
            var listRefulings = new List<Refueling>();
            listVehicleHistories.Add(new CarHistory
            {
                Id = "1",
                ApplicationUserID = "1a",
                RefulingRef = "1r",
                CreatedDateTime = DateTime.Now,
                Name = "Tankowanie",
                IsActive = true,
                CreatedById = "1a"
            });

            listRefulings.Add(new Refueling
            {
                Id = "1r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 1003,
                CreatedDateTime = DateTime.Now
            });

            var vehicleRepository = new Mock<IVehicleRepository>();
            var mapper = new Mock<IMapper>();
            vehicleRepository.Setup(x => x.GetAllVehicleHistory()).Returns(listVehicleHistories.AsQueryable());
            vehicleRepository.Setup(x => x.GetAllRefuelings()).Returns(listRefulings.AsQueryable());
            var vehicleService = new VehicleService(vehicleRepository.Object, mapper.Object);
            //Act
            var result = vehicleService.GetUserVehicleHistory("1a");
            //Assert
            result.Should().NotBeNull();
            result.CarHistoryList.Should().HaveCount(1);
        }

        [Fact]
        public void ShouldReturnLastMillagerBeforeRefueling()
        {
            //Arrange
            var listRefulings = new List<Refueling>();
            listRefulings.Add(new Refueling
            {
                Id = "1r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 900,
                CreatedDateTime = DateTime.Now,
                VehicleId = 10
            });
            listRefulings.Add(new Refueling
            {
                Id = "2r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 1000,
                CreatedDateTime = DateTime.Now,
                VehicleId = 10
            });
            listRefulings.Add(new Refueling
            {
                Id = "3r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 1100,
                CreatedDateTime = DateTime.Now,
                VehicleId = 10
            });

            var vehicleRepository = new Mock<IVehicleRepository>();
            var mapper = new Mock<IMapper>();

            vehicleRepository.Setup(x => x.GetAllRefuelings()).Returns(listRefulings.AsQueryable());
            var vehicleService = new VehicleService(vehicleRepository.Object, mapper.Object);
            //Act
            int result = vehicleService.GetLastRefuelingMileage(10);
            //Assert
            result.Should().Be(1100);
            result.Should().BeGreaterThan(0);
            result.Should().BePositive();
        }

        [Fact]
        public void ShouldReturnAllFuelsType()
        {

            var firstFuelType = new VehicleFuelType();
            firstFuelType.Id = 1;
            firstFuelType.Name = "Gaz";
            var secondFuelType = new VehicleFuelType();
            secondFuelType.Id = 2;
            secondFuelType.Name = "Benzyna";
            var thirdFuelType = new VehicleFuelType();
            thirdFuelType.Id = 3;
            thirdFuelType.Name = "Olej napędowy";
            var fuelTypesList = new List<VehicleFuelType>();
            fuelTypesList.Add(firstFuelType);
            fuelTypesList.Add(secondFuelType);
            fuelTypesList.Add(thirdFuelType);

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.ConfigurationProvider)
                .Returns(
                    () => new MapperConfiguration(
                        cfg => { cfg.CreateMap<VehicleFuelType, VehicleFuelTypeVm>(); }));

            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(x => x.GetVehicleFuelTypes()).Returns(fuelTypesList.AsQueryable());

            var vehicleService = new VehicleService(vehicleRepository.Object, mapper.Object);

            var vehicleRepositoryWithoutFuelNames = new Mock<IVehicleRepository>();
            var vehicleServiceWithoutFuelNames = new VehicleService(vehicleRepositoryWithoutFuelNames.Object, mapper.Object);

            var allFuels = vehicleService.GetAllFuelsTypes();
            var withoutFuelNames = vehicleServiceWithoutFuelNames.GetAllFuelsTypes();

            allFuels.Should().HaveCount(3);
            allFuels[0].Name.Equals("Gaz");
            allFuels[1].Name.Equals("Benzyna");
            allFuels[2].Name.Equals("Olej napędowy");

            withoutFuelNames.Should().BeNullOrEmpty();
        }
        //[Fact]
        //public void ShouldReturnVehicleDetails()
        //{
        //    //Arrange
        //    var fuelTypes = new List<VehicleFuelType>() { new VehicleFuelType() { Id = 1, IsActive = true, Name = "Benzyna" } };
        //    var brands = new List<VehicleBrandName>() { new VehicleBrandName() { Id = 1, IsActive = true, Name = "Opel" } };
        //    var vehicleTypes = new List<VehicleType>() { new VehicleType() { Id = 1, IsActive = true, Name = "Osobowy" } };
        //    var vehicle = new Vehicle()
        //    {
        //        ApplicationUserID = "123@",
        //        Capacity = 1500,
        //        CreatedById = "123@",
        //        CreatedDateTime = new DateTime(2000, 10, 10),
        //        DateOfFirstRegistration = new DateTime(1999, 12, 12),
        //        EngineCapacity = 1300,
        //        EnginePower = 120,
        //        Id = 1,
        //        IsActive = true,
        //        IsGasInstalation = true,
        //        IsRegisterdInPoland = true,
        //        Model = "Astra",
        //        VehicleBrandNameId = 1,
        //        VehicleFuelTypeId = 1,
        //        ProductionDate = new DateTime(1999, 01, 01),
        //        RegistrationNumber = "LUB6127",
        //        VehicleTypeId = 1,
        //        Millage = 15000,
        //        OwnWeight = 800,
        //        Vin = "ABCD12341082KRPLS",
        //        PermissibleGrossWeight = 2000
        //    };

        //    var mapper = new Mock<IMapper>();
        //    mapper.Setup(x => x.ConfigurationProvider)
        //        .Returns(
        //            () => new MapperConfiguration(
        //                cfg => { cfg.CreateMap<VehicleDetailsVm, Vehicle>().ReverseMap(); }));

        //    var repository = new Mock<IVehicleRepository>();
        //    repository.Setup(x => x.GetVehicleFuelTypes()).Returns((fuelTypes.AsQueryable()));
        //    repository.Setup(x => x.GetVehicleTypes()).Returns(vehicleTypes.AsQueryable());
        //    repository.Setup(x => x.GetVehicleBrandNames()).Returns(brands.AsQueryable());
        //    repository.Setup(x => x.GetVehicleById(1)).Returns(vehicle);

        //    var service = new VehicleService(repository.Object, mapper.Object);

        //    //Act
        //    var vehicleDetails = service.GetVehicleDetails(1);

        //    //Assert

        //    vehicleDetails.Millage.Should().Be(15000);
        //}
        [Fact]
        public void ShouldReturnFuelTypeNameById()
        {
            //Arrange
            var fuelTypes = new List<FuelForRefueling>()
            {
                new FuelForRefueling() { Id = 1, IsActive = true, Name = "Benzyna" },
                new FuelForRefueling(){ Id = 2, IsActive = false, Name = "Gaz" },
                new FuelForRefueling(){ Id = 3, IsActive = true, Name = "" }
            };
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.ConfigurationProvider)
                .Returns(
                    () => new MapperConfiguration(
                        cfg => { cfg.CreateMap<FuelForRefueling, FuelTypeForRefuelingForListVm>(); }));

            var repository = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetFuelTypesForRefueling()).Returns((fuelTypes.AsQueryable()));

            var service = new VehicleService(repository.Object, mapper.Object);
            //Act
            var fuelName = service.GetFuelNameById(1);
            var fuelNameTwo = service.GetFuelNameById(2);
            var fuelNameThree = service.GetFuelNameById(3);
            var fuelNameFour = service.GetFuelNameById(4);
            //Assert
            fuelName.Should().Be("Benzyna");
            fuelNameTwo.Should().Be("Brak danych - skontaktuj się z administratorem");
            fuelNameThree.Should().Be("Brak danych - skontaktuj się z administratorem");
            fuelNameFour.Should().Be("Brak danych - skontaktuj się z administratorem");
        }
        [Fact]
        public void ShouldReturnUnitsOfFuel()
        {
            //Arrange
            var unitsOfFuel = new List<UnitOfFuel>()
            {
            new UnitOfFuel() { Id =1,Name = "Litr", IsActive = true },
            new UnitOfFuel() { Id =2,Name = "Kilo Wat", IsActive = true },
            new UnitOfFuel() { Id =3,Name = "Galon", IsActive = true },
            new UnitOfFuel() { Id =4,Name = "Baryłka", IsActive = false }
            };

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.ConfigurationProvider)
                .Returns(
                    () => new MapperConfiguration(
                        cfg => { cfg.CreateMap<UnitOfFuelForListVm, UnitOfFuel>().ReverseMap(); }));

            var repository = new Mock<IVehicleRepository>();
            var repositoryWithoutUnits = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetUnitsOfFuel()).Returns(unitsOfFuel.AsQueryable());
            var service = new VehicleService(repository.Object, mapper.Object);
            var serviceWithoutUnits = new VehicleService(repositoryWithoutUnits.Object, mapper.Object);
            //Act
            var firstResult = service.GetUnitsOfFuels();
            var secondResult = serviceWithoutUnits.GetUnitsOfFuels();
            //Assert
            firstResult.UnitOfFuelList.Should().HaveCount(3);
            firstResult.UnitOfFuelList.Should().NotBeNullOrEmpty();
            firstResult.UnitOfFuelList.Should().BeInDescendingOrder(x => x.Name);
            firstResult.UnitOfFuelList[0].Name.Should().Be("Litr");
            firstResult.UnitOfFuelList[1].Name.Should().Be("Kilo Wat");
            firstResult.UnitOfFuelList[2].Name.Should().Be("Galon");
            secondResult.UnitOfFuelList.Should().HaveCount(0);
            secondResult.UnitOfFuelList.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ShouldReturnUserCars()
        {

            var firstBrand = new VehicleBrandName() { Id = 1, Name = "Opel" };
            var secondBrand = new VehicleBrandName() { Id = 2, Name = "Toyota" };
            var thirdBrand = new VehicleBrandName() { Id = 3, Name = "Hyundai" };
            //Arrange
            var vehicleList = new List<Vehicle>()
            {
                new Vehicle(){Id = 1, ApplicationUserID = "1user",IsActive = true,Model = "Corsa",VehicleBrandNameId = 1, VehicleBrandName = firstBrand,RegistrationNumber ="LUB6127"},
                new Vehicle(){Id = 2, ApplicationUserID = "1user",IsActive = true,Model = "Astra",VehicleBrandNameId = 1,VehicleBrandName=firstBrand,RegistrationNumber ="LUB6128"},
                new Vehicle(){Id = 3, ApplicationUserID = "1user",IsActive = true,Model = "Verso",VehicleBrandNameId =2, VehicleBrandName = secondBrand,RegistrationNumber ="LUB6129"},
                new Vehicle(){Id = 4, ApplicationUserID = "2user",IsActive = true,Model = "I30",VehicleBrandNameId =3, VehicleBrandName = thirdBrand,RegistrationNumber ="LUB6130"},
                new Vehicle(){Id = 5, ApplicationUserID = "2user",IsActive = false,Model = "Tucson",VehicleBrandNameId =3,VehicleBrandName = thirdBrand,RegistrationNumber ="LUB6131"},
                new Vehicle(){Id = 6, ApplicationUserID = "3user",IsActive = true,Model = "Santa Fe",VehicleBrandNameId =3,VehicleBrandName = thirdBrand,RegistrationNumber ="LUB6132"},
                new Vehicle(){Id = 7, ApplicationUserID = "2user",IsActive = true,Model = "Santa Fe",VehicleBrandNameId =3,VehicleBrandName = thirdBrand,RegistrationNumber ="LUB6133"}
            };

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.ConfigurationProvider)
                .Returns(
                    () => new MapperConfiguration(
                        cfg =>
                        {
                            cfg.CreateMap<UserCarsForListVm, Vehicle>().ReverseMap()
           .ForMember(s => s.Name, opt => opt.MapFrom(x => string.Concat(x.VehicleBrandName.Name, " ", x.Model, " ", x.RegistrationNumber)));
                        }));

            var repository = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetVehicles()).Returns(vehicleList.AsQueryable());
            var service = new VehicleService(repository.Object, mapper.Object);

            var repositoryWithoutObject = new Mock<IVehicleRepository>();
            var mapperW = new Mock<IMapper>();
            var serviceWithoutObject = new VehicleService(repositoryWithoutObject.Object, mapperW.Object);
            //Act
            var firstUserCars = service.GetUserCars("1user");
            var secondUserCars = service.GetUserCars("2user");
            var thirdUserCars = service.GetUserCars("2usaser");
            var userCarsWithoutObject = serviceWithoutObject.GetUserCars("1user");
            //Assert
            firstUserCars.UserCars.Should().HaveCount(3);
            firstUserCars.UserCars.Should().NotBeNullOrEmpty();
            firstUserCars.UserCars[0].Name.Should().NotBeNullOrEmpty();
            firstUserCars.UserCars[0].Name.Should().Be("Opel Astra LUB6128");
            firstUserCars.UserCars[1].Name.Should().Be("Opel Corsa LUB6127");
            firstUserCars.UserCars[1].Id.Should().Be(1);
            firstUserCars.UserCars.Should().NotBeInDescendingOrder(x => x.Name);
            firstUserCars.UserCars.Should().OnlyHaveUniqueItems(x => x.Id);

            secondUserCars.UserCars.Should().HaveCount(2);
            secondUserCars.UserCars.Should().NotBeNullOrEmpty();
            secondUserCars.UserCars.Should().NotBeInDescendingOrder(x => x.Name);
            secondUserCars.UserCars[0].Name.Should().Be("Hyundai I30 LUB6130");
            secondUserCars.UserCars[0].Id.Should().Be(4);
            secondUserCars.UserCars.Should().OnlyHaveUniqueItems(x => x.Id);

            thirdUserCars.UserCars.Should().HaveCount(0);
            thirdUserCars.UserCars.Should().BeNullOrEmpty();

            userCarsWithoutObject.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnAllVehicleBranNames()
        {
            //Arrange
            var listVehicleBrands = new List<VehicleBrandName>()
            {
            new VehicleBrandName() { Id = 1, Name = "Opel" , IsActive = true},
            new VehicleBrandName() { Id = 2, Name = "Toyota" , IsActive = true},
            new VehicleBrandName() { Id = 3, Name = "Hyundai" , IsActive = false},
            new VehicleBrandName() { Id = 4, Name = "Nissan" , IsActive = true},
            new VehicleBrandName() { Id = 5, Name = "Dodge" , IsActive = true }
            };

            var repository = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetVehicleBrandNames()).Returns(listVehicleBrands.AsQueryable());

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.ConfigurationProvider)
                .Returns(
                    () => new MapperConfiguration(
                        cfg =>
                        {
                            cfg.CreateMap<VehicleBrandName, VehicleBrandNameVm>();
                        }));

            var service = new VehicleService(repository.Object, mapper.Object);

            var repositoryWithoutElements = new Mock<IVehicleRepository>();
            var mapperWithoutConfiguration = new Mock<IMapper>();
            var serviceWithoutElements = new VehicleService(repositoryWithoutElements.Object, mapperWithoutConfiguration.Object); ;
            //Act
            var firstListBrands = service.GetAllBrandNames();
            var secondListBrandsWithoutElements = serviceWithoutElements.GetAllBrandNames();
            //Asserts
            firstListBrands.Should().BeInAscendingOrder(x => x.Name);
            firstListBrands.Should().HaveCount(4);
            firstListBrands[0].Name.Should().Be("Dodge");
            firstListBrands[0].Id.Should().Be(5);
            firstListBrands.Should().OnlyHaveUniqueItems(x => x.Id);
            firstListBrands.Should().NotBeNullOrEmpty();
            firstListBrands.Should().NotBeNull();

            secondListBrandsWithoutElements.Should().BeNullOrEmpty();
            secondListBrandsWithoutElements.Should().BeNull();


        }
    }
}
