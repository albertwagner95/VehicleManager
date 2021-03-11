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

        /// <summary>
        /// A method that calculates the combustion of a specific event
        /// </summary>
        /// <param name="newRefulingVm">A parameter is a specific event.</param>
        /// <returns>Returns the burning of an event</returns>
        public static decimal ReturnBurningPerOneHoundredKilometers(NewEventVm newRefulingVm)
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
        /// <summary>
        /// A method that returns the average fuel consumption for several events.
        /// </summary>
        /// <param name="events">The method takes a list of events for which it will calculate average fuel consumption.</param>
        /// <returns>The method returns the average fuel consumption for specific events.</returns>
        public static decimal ReturnBurningPerOneHoundredKilometers(List<VehicleEventsForListVm> events)
        {
            decimal sumOfAverageFuelConsumption = events.Where(x => x.BurningFuelPerOneHundredKilometers > 0).Sum(x => x.BurningFuelPerOneHundredKilometers);
            int countEvents = events.Where(x => x.BurningFuelPerOneHundredKilometers > 0).Count();
            if (countEvents == 0)
            {
                return 0;
            }
            else
            {
                decimal result = decimal.Divide(sumOfAverageFuelConsumption, countEvents);
                return decimal.Round(result, 2);
            }
        }
        public static string ReturnAvgBurningForChart(List<VehicleEventsForListVm> events)
        {
            string avgFuelBurnings = "";
            foreach (var item in events)
            {
                avgFuelBurnings = string.Concat(avgFuelBurnings, item.BurningFuelPerOneHundredKilometers, ",");
            }
            avgFuelBurnings = avgFuelBurnings.Remove(avgFuelBurnings.Length-1, 1);
            avgFuelBurnings = string.Concat("[", avgFuelBurnings, "]");

            return avgFuelBurnings;
        }
        public static string ReturnKilometersForChart(List<VehicleEventsForListVm> events)
        {
            string kilometers = "";
             
            foreach (var item in events)
            {   
                kilometers = string.Concat(kilometers, item.MeterStatus, ",");
            }
            kilometers = kilometers.Remove(kilometers.Length - 1, 1);
            kilometers = string.Concat("[", kilometers, "]");

            return kilometers;
        }
    }
}
