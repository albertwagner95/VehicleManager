using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;
using Xunit;

namespace VehicleManager.Tests.Services
{
    public class VehicleServiceTests
    {
        [Fact]
        public void ShouldReturnBrandName()
        {
            //Arrange
            var ford = new VehicleBrandName() { Id = 1, Name = "Ford" };
            var opel = new VehicleBrandName() { Id = 2, Name = "Opel" };
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
    }
}
