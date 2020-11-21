using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Application.Services;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Model;
using Xunit;

namespace VehicleManager.Tests.Services
{
    public class VehicleServiceTests
    {
        [Fact]
        public void shouldReturnBrandName()
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
            var vehicleService = new VehicleService(vehicleRepository.Object,mapper.Object);

            var result = vehicleService.GetBrandName(1);
            var secondResult = vehicleService.GetBrandName(2);

            result.Should().Be("Ford");
            secondResult.Should().Be("Opel");
        }
    }
}
