using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Services.Helpers;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Application.ViewModels.Vehicle;
using Xunit;

namespace VehicleManager.Tests.Helpers
{
    public class VehicleServiceHelpersTests
    {
        [Fact]
        public void ShouldBeReturnBurnigFuelPerOneHounderKilometers()
        {
            //Arrange
            //Correct data
            var firstModel = new NewEventVm()
            {
                LastMeters = 100,
                MeterStatus = 550,
                AmountOfFuel = 30,
                IsRefulingFull = true
            };
            //Kilometers before refueling is greather than actually meter status
            var secondModel = new NewEventVm()
            {
                LastMeters = 1200,
                MeterStatus = 1190,
                IsRefulingFull = true
            };
            //Kilometers before refueling is equal with actually meter status
            var thirdModel = new NewEventVm()
            {
                LastMeters = 1200,
                MeterStatus = 1200,
                IsRefulingFull = true
            };
            var fourthModel = new NewEventVm()
            {
                LastMeters = 1200,
                MeterStatus = 1390,
                IsRefulingFull = true
            };
            //Act
            decimal burningFuelPerOneHoundredKilometersIsRefuelingFullTrue = VehicleServiceHelpers
                .ReturnBurningPerOneHoundredKilometers(firstModel);

            decimal burningFuelPerOneHoundredKilometersIsRefuelingFullFalse = VehicleServiceHelpers
                .ReturnBurningPerOneHoundredKilometers(secondModel);

            decimal burningFuelPerOneHoundredKilometersIsRefuelingAfterRefuelingIsLessThanBefore = VehicleServiceHelpers
                .ReturnBurningPerOneHoundredKilometers(thirdModel);

            decimal burningFuelPerOneHoundredKilometersIsRefuelingAfterRefuelingIsEqualThanBefore = VehicleServiceHelpers
                .ReturnBurningPerOneHoundredKilometers(fourthModel);
            //Assert
            burningFuelPerOneHoundredKilometersIsRefuelingFullTrue.Should().Be(6.6667M);
            burningFuelPerOneHoundredKilometersIsRefuelingFullTrue.Should().BePositive();
            burningFuelPerOneHoundredKilometersIsRefuelingFullTrue.Should().NotBe(0M);

            burningFuelPerOneHoundredKilometersIsRefuelingFullFalse.Should().Be(0M);

            burningFuelPerOneHoundredKilometersIsRefuelingAfterRefuelingIsLessThanBefore.Should().Be(0);

            burningFuelPerOneHoundredKilometersIsRefuelingAfterRefuelingIsEqualThanBefore.Should().Be(0);
        }
        [Fact]
        public void ShouldReturnAverageFuelConsumptionForAEvents()
        {
            //Arrange
            List<VehicleEventsForListVm> listEvents = Initializer.Initializer.VehicleEventsForListVmInitializer();
            List<VehicleEventsForListVm> listEventsEmpty = new List<VehicleEventsForListVm>();
            //Act
            decimal result = VehicleServiceHelpers.ReturnBurningPerOneHoundredKilometers(listEvents);
            decimal resultDivideZero = VehicleServiceHelpers.ReturnBurningPerOneHoundredKilometers(listEventsEmpty);
            //Asserts
            result.Should().Be(22.88M);
            result.Should().BePositive();
            resultDivideZero.Should().Be(0);
        }
    }
}
