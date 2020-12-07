using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.ViewModels.AddressVm;
using Xunit;
using static VehicleManager.Application.ViewModels.AddressVm.NewRefulingVm;

namespace VehicleManager.Tests.Validations
{
    public class RefuelingValidationTests
    {
        
        private readonly NewRefuelingValidation _validator = new NewRefuelingValidation();
        public NewRefulingVm model = new NewRefulingVm();


        [Fact]
        public void ShouldHaveErrorWhenLastMillageIsGraeaterThanActuallyMilleage()
        {
            model.MeterStatus = 1000;
            model.LastMeters = 3000;
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(ms=>ms.MeterStatus);
        }
    }
}
