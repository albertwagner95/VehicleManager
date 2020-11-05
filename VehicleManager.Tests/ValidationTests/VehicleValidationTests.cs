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
            model.DateOfFirstRegistration = new DateTime(2002,11,12);
            model.YearHelper = 2004;
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(vin => vin.YearHelper);

        }



    }
}
