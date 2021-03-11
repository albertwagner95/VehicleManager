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
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;
using VehicleManager.Tests.Initializer;
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
            //Act
            var result = vehicleService.GetBrandName(1);
            var secondResult = vehicleService.GetBrandName(2);
            var thirdResult = vehicleService.GetBrandName(3);
            //Asertions
            result.Should().Be("Ford");
            secondResult.Should().Be("Opel");
            thirdResult.Should().Be("");
        }
        [Fact]
        public void ShouldReturnCarHistory()
        {
            //Arrange
            List<CarHistory> listVehicleHistories = new List<CarHistory>();
            List<Event> listEvents = new List<Event>();
            listVehicleHistories.Add(new CarHistory
            {
                Id = "1",
                ApplicationUserID = "1a",
                EventRef = "1r",
                CreatedDateTime = DateTime.Now,
                Name = "Tankowanie",
                IsActive = true,
                CreatedById = "1a"
            });
            listEvents.Add(new Event
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
            vehicleRepository.Setup(x => x.GetAllRefuelings()).Returns(listEvents.AsQueryable());
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
            List<Event> listRefulings = Initializer.Initializer.EvntInitializer();

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

            var fuelTypesList = Initializer.Initializer.FuelTypesInitializer();

            IMapper mapper = MapperConfig.Mapper();

            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(x => x.GetVehicleFuelTypes()).Returns(fuelTypesList.AsQueryable());

            var vehicleService = new VehicleService(vehicleRepository.Object, mapper);

            var vehicleRepositoryWithoutFuelNames = new Mock<IVehicleRepository>();
            var vehicleServiceWithoutFuelNames = new VehicleService(vehicleRepositoryWithoutFuelNames.Object, mapper);

            var allFuels = vehicleService.GetAllFuelsTypes();
            var withoutFuelNames = vehicleServiceWithoutFuelNames.GetAllFuelsTypes();

            allFuels.Should().HaveCount(3);
            allFuels[0].Name.Equals("Gaz");
            allFuels[1].Name.Equals("Benzyna");
            allFuels[2].Name.Equals("Olej napędowy");

            withoutFuelNames.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ShouldReturnFuelTypeNameById()
        {
            //Arrange
            List<FuelForRefueling> fuelTypes = Initializer.Initializer.FuelForRefuelingsInitializer();
            IMapper mapper = MapperConfig.Mapper();

            Mock<IVehicleRepository> repository = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetFuelTypesForRefueling()).Returns((fuelTypes.AsQueryable()));

            VehicleService service = new VehicleService(repository.Object, mapper);
            //Act
            string fuelName = service.GetFuelNameById(1);
            string fuelNameTwo = service.GetFuelNameById(2);
            string fuelNameThree = service.GetFuelNameById(3);
            string fuelNameFour = service.GetFuelNameById(4);
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
            var unitsOfFuel = Initializer.Initializer.UnitsFuelInitializer();

            IMapper mapper = MapperConfig.Mapper();

            var repository = new Mock<IVehicleRepository>();
            var repositoryWithoutUnits = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetUnitsOfFuel()).Returns(unitsOfFuel.AsQueryable());
            var service = new VehicleService(repository.Object, mapper);
            var serviceWithoutUnits = new VehicleService(repositoryWithoutUnits.Object, mapper);
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

            List<Vehicle> vehicleList = Initializer.Initializer.VehiclesInitalizer();

            IMapper mapper = MapperConfig.Mapper();

            var repository = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetVehicles()).Returns(vehicleList.AsQueryable());
            var service = new VehicleService(repository.Object, mapper);

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
            var listVehicleBrands = Initializer.Initializer.VehicleBrandsInitializer();

            var repository = new Mock<IVehicleRepository>();
            repository.Setup(x => x.GetVehicleBrandNames()).Returns(listVehicleBrands.AsQueryable());

            IMapper mapper = MapperConfig.Mapper();

            var service = new VehicleService(repository.Object, mapper);
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

        [Fact]
        public void ShouldReturnAllKindOfEvents()
        {
            //act
            var kindOfEvents = Initializer.Initializer.KindOfEventInitializer();


            IMapper mapper = MapperConfig.Mapper();

            Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(x => x.GetAllKindOfEvents()).Returns(kindOfEvents.AsQueryable());

            VehicleService vehicleService = new VehicleService(vehicleRepository.Object, mapper);
            //arrange

            List<KindOfEventsListVm> kindOfEventsCorrect = vehicleService.GetAllKindsOfEvents();
            List<KindOfEventsListVm> kindOfEventsIncorrect = null;
            //asserts 

            kindOfEventsCorrect[0].Name.Should().Be("Myjnia");
            kindOfEventsCorrect[3].Name.Should().Be("Wymiana opon");
            kindOfEventsCorrect.Should().BeInAscendingOrder(x => x.Name);
            kindOfEventsCorrect.Should().NotBeNull();

            kindOfEventsIncorrect.Should().BeNull();
        }
        [Fact]
        public void ShouldReturnVehicleStats()
        {
            //Act
            List<Event> vehicleEventsForStatsInitalizatotion = Initializer.Initializer.EventInitializerForStats();
            IMapper mapper = MapperConfig.Mapper();
            Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(x => x.GetAllEvents()).Returns(vehicleEventsForStatsInitalizatotion.AsQueryable());

            var vehicleService = new VehicleService(vehicleRepository.Object, mapper);
            //Arrange
            var res = vehicleService.GetVehicleStats(10, null, null);
            var res2 = vehicleService.GetVehicleStats(10, "2021-1-1", "2021-1-14");
            //Asserts
            res.Kilometers.Should().Be(1100);
            res.TotalCostForEvents.Should().Be(1703.10M);
            res.TheBiggestPriceForEvent.Should().Be(1400.00M);
            res.TheSmallestPriceForEvent.Should().Be(81.55M);

            res2.Kilometers.Should().Be(100);
            res2.TotalCostForEvents.Should().Be(95.60M);
            res2.TheBiggestPriceForEvent.Should().Be(95.60M);
            res2.TheSmallestPriceForEvent.Should().Be(95.60M);

        }
        [Fact]
        public void ShouldReturnEventsBetweendTwoDays()
        {
            //Act
            List<Event> vehicleEventsForStatsInitalizatotion = Initializer.Initializer.EventInitializerForStats();
            IMapper mapper = MapperConfig.Mapper();
            Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
            Mock<IVehicleRepository> vehicleRepositoryWithoutElements = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(x => x.GetAllEvents()).Returns(vehicleEventsForStatsInitalizatotion.AsQueryable());
            VehicleService vehicleService = new VehicleService(vehicleRepository.Object, mapper);
            VehicleService vehicleServiceWithoutObjects = new VehicleService(vehicleRepositoryWithoutElements.Object, mapper);

            //Arrange
            var eventsList = vehicleService.GetEventsBetweenTwoDates(10, "2021-01-10", "2021-01-30");
            var eventsListOptTwo = vehicleService.GetEventsBetweenTwoDates(10, "2021-02-1", "2021-02-3");
            var eventsListOptThree = vehicleService.GetEventsBetweenTwoDates(1, "2021-01-1", "2021-01-1");
            var eventsListOptFour = vehicleService.GetEventsBetweenTwoDates(10, "x", "x");
            var eventsWithoutObjects = vehicleServiceWithoutObjects.GetEventsBetweenTwoDates(1, "xx", "xx");
            var eventsWithoutObjectsTwo = vehicleServiceWithoutObjects.GetEventsBetweenTwoDates(2, "xx", "xx");

            //Asserts
            eventsList.Should().HaveCount(3);
            eventsListOptTwo.Should().BeEmpty();
            eventsListOptThree.Should().BeEmpty();
            eventsListOptFour.Should().HaveCount(4);
            eventsWithoutObjects.Should().BeEmpty();
            eventsWithoutObjectsTwo.Should().BeEmpty();
        }


    }
}
