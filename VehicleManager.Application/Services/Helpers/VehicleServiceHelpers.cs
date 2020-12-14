using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Application.ViewModels.Vehicle;

namespace VehicleManager.Application.Services.Helpers
{
    public class VehicleServiceHelpers
    {
        public static decimal ReturnBurningPerOneHoundredKilometers(NewRefulingVm newRefulingVm)
        {
            if (newRefulingVm.IsRefulingFull == false)
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
        public static int GetMillageBeforeEvent(List<RefuelDetailsVm> listEvents)
        {
            if(listEvents != null && listEvents.Count>1)
            {
                var milleage = listEvents.OrderByDescending(x => x.MeterStatus)
                    .Select(x => x.MeterStatus).ToList()[1];
                return milleage;
            }

            return 0;
        }
    }
}
