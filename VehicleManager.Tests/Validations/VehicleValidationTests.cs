using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.ViewModels.Vehicle;
using Xunit;
using static VehicleManager.Application.ViewModels.Vehicle.NewVehicleVm;

namespace VehicleManager.Tests.ValidationTests
{
    public class VehicleValidationTests
    {
        private NewVehicleValidation _validator = new NewVehicleValidation();
        public NewVehicleVm model = new NewVehicleVm();


        [Fact]
        public void ShouldHaveErrorWhenRegistrationNumberIsSoLong()
        {
            model.RegistrationNumber = "aaaa12aa12";
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(rn => rn.RegistrationNumber);
        }

        [Fact]
        public void ShouldHaveErrorWhenApplicationUserIdIsNull()
        {
            model.ApplicationUserID = null;
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(id => id.ApplicationUserID);
        }
        [Fact]
        public void ShouldHaveErrorWhenVinHas()
        {
            model.Vin = "111144424111134322";
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(vin => vin.Vin);
        }
        [Fact]
        public void ShouldHaveErrorWhenLastSixCharactersAreOnlyNumbers()
        {
            model.Vin = "1234123412341234a";
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(vin => vin.Vin);
        }
        [Fact]
        public void ShouldHaveErrorWhenFirstFourCharacterAreSame()
        {
            model.Vin = "1111aaaa";
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(vin => vin.Vin);
        }

        [Fact]
        public void ShouldHaveErrorWhenDataProductionIsGratherThenDataFirstRegistration()
        {
            model.DateOfFirstRegistration = new DateTime(2002, 11, 12);
            model.YearHelper = 2004;
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(vin => vin.YearHelper);

        }

        [Fact]
        public void ShouldHaveErrorWhenOwnWeightIsGreatherThanPermisibleGrossWeight()
        {
            model.OwnWeight = 111;
            model.PermissibleGrossWeight = 110;
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(ow => ow.OwnWeight);
        }
        [Fact]
        public void ShouldHaveErrorWhenCapacityANdPermissibleGrossWeightWillBeHaveLessThanTwoCharacters()
        {
            model.OwnWeight = 1;
            model.PermissibleGrossWeight = 1;
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(ow => ow.OwnWeight);
            result.ShouldHaveValidationErrorFor(pgw => pgw.PermissibleGrossWeight);
        }

        [Fact]
        public void ShouldHaveErrorWhenMillageIsLessThanZero()
        {
            model.Millage = -2;
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(mlg => mlg.Millage);
        }

        [Fact]
        public void ShouldHaveErrorWhenEngineCapacityIsLessThanZero()
        {
            model.EngineCapacity = -2;
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(v => v.EngineCapacity);
        }
        [Fact]
        public void ShouldHaveErrorWhenYearProductionIsToLow() // less then 1799 year
        {
            model.DateOfFirstRegistration = new DateTime(1001, 11, 11);
            model.YearHelper = 1002;
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(v => v.YearHelper);
        }
        [Fact]
        public void ShoudHaveErrorWhenProductionYearIsGreatherThanThisYear()
        {
            // model.DateOfFirstRegistration = new DateTime(DateTime.Today.Year+2, 11, 11);
            model.YearHelper = DateTime.Today.Year + 1;
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(v => v.YearHelper);
        }

        [Fact]
        public void ShouldHaveErrorWhenEnginePowerIsLessThanZero()
        {
            model.EnginePower = -2;
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(v => v.EnginePower);
        }
    }
}