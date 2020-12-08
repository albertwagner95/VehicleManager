using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.ViewModels.AddressVm;

namespace VehicleManager.Application.Services.Helpers
{
    public class VehicleServiceHelpers
    {   
        public static decimal ReturnBurningPerOneHoundredKilometers(NewRefulingVm newRefulingVm)
        {
            if(newRefulingVm.IsRefulingFull == false)
            {
                return 0M;
            }
            else if (newRefulingVm.LastMeters >= newRefulingVm.MeterStatus)
            {
                return 0M;
            }

            int differenceKilometersBetweenRefuling = newRefulingVm.MeterStatus - newRefulingVm.LastMeters;

            decimal burningFuelPerOneHoundredKilometers = decimal.Multiply(decimal.Divide(newRefulingVm.AmountOfFuel, differenceKilometersBetweenRefuling), 100);
            burningFuelPerOneHoundredKilometers = decimal.Round(burningFuelPerOneHoundredKilometers, 4);
            return burningFuelPerOneHoundredKilometers;
        }
    }
}
