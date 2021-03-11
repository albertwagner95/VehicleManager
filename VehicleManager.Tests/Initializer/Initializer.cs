using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Tests.Initializer
{
    public static class Initializer
    {
        public static List<KindOfEvent> KindOfEventInitializer()
        {
            var firstEvent = new KindOfEvent() { Id = 1, Name = "Tankowanie" };
            var secondEvent = new KindOfEvent() { Id = 2, Name = "Naprawa" };
            var thirdEvent = new KindOfEvent() { Id = 3, Name = "Myjnia" };
            var fourthEvent = new KindOfEvent() { Id = 4, Name = "Wymiana opon" };

            List<KindOfEvent> kindOfEvents = new List<KindOfEvent>();
            kindOfEvents.Add(firstEvent);
            kindOfEvents.Add(secondEvent);
            kindOfEvents.Add(thirdEvent);
            kindOfEvents.Add(fourthEvent);
            return kindOfEvents;
        }
        public static List<VehicleBrandName> VehicleBrandsInitializer()
        {
            List<VehicleBrandName> listVehicleBrands = new List<VehicleBrandName>()
            {
            new VehicleBrandName() { Id = 1, Name = "Opel" , IsActive = true},
            new VehicleBrandName() { Id = 2, Name = "Toyota" , IsActive = true},
            new VehicleBrandName() { Id = 3, Name = "Hyundai" , IsActive = false},
            new VehicleBrandName() { Id = 4, Name = "Nissan" , IsActive = true},
            new VehicleBrandName() { Id = 5, Name = "Dodge" , IsActive = true }
            };

            return listVehicleBrands;
        }

        public static List<Vehicle> VehiclesInitalizer()
        {

            var listVehicleBrands = VehicleBrandsInitializer();

            //Arrange
            List<Vehicle> vehicleList = new List<Vehicle>()
            {
                new Vehicle(){Id = 1, ApplicationUserID = "1user",IsActive = true,Model = "Corsa",VehicleBrandNameId = 1, VehicleBrandName = listVehicleBrands[0],RegistrationNumber ="LUB6127"},
                new Vehicle(){Id = 2, ApplicationUserID = "1user",IsActive = true,Model = "Astra",VehicleBrandNameId = 1,VehicleBrandName=listVehicleBrands[0],RegistrationNumber ="LUB6128"},
                new Vehicle(){Id = 3, ApplicationUserID = "1user",IsActive = true,Model = "Verso",VehicleBrandNameId =2, VehicleBrandName = listVehicleBrands[1],RegistrationNumber ="LUB6129"},
                new Vehicle(){Id = 4, ApplicationUserID = "2user",IsActive = true,Model = "I30",VehicleBrandNameId =3, VehicleBrandName = listVehicleBrands[2],RegistrationNumber ="LUB6130"},
                new Vehicle(){Id = 5, ApplicationUserID = "2user",IsActive = false,Model = "Tucson",VehicleBrandNameId =3,VehicleBrandName = listVehicleBrands[2],RegistrationNumber ="LUB6131"},
                new Vehicle(){Id = 6, ApplicationUserID = "3user",IsActive = true,Model = "Santa Fe",VehicleBrandNameId =3,VehicleBrandName = listVehicleBrands[2],RegistrationNumber ="LUB6132"},
                new Vehicle(){Id = 7, ApplicationUserID = "2user",IsActive = true,Model = "Santa Fe",VehicleBrandNameId =3,VehicleBrandName = listVehicleBrands[2],RegistrationNumber ="LUB6133"}
            };
            return vehicleList;
        }

        public static List<UnitOfFuel> UnitsFuelInitializer()
        {
            var unitsOfFuel = new List<UnitOfFuel>()
            {
            new UnitOfFuel() { Id =1,Name = "Litr", IsActive = true },
            new UnitOfFuel() { Id =2,Name = "Kilo Wat", IsActive = true },
            new UnitOfFuel() { Id =3,Name = "Galon", IsActive = true },
            new UnitOfFuel() { Id =4,Name = "Baryłka", IsActive = false }
            };
            return unitsOfFuel;
        }

        public static List<FuelForRefueling> FuelForRefuelingsInitializer()
        {
            List<FuelForRefueling> fuelTypes = new List<FuelForRefueling>()
            {
                new FuelForRefueling() { Id = 1, IsActive = true, Name = "Benzyna" },
                new FuelForRefueling(){ Id = 2, IsActive = false, Name = "Gaz" },
                new FuelForRefueling(){ Id = 3, IsActive = true, Name = "" }
            };

            return fuelTypes;
        }
        public static List<VehicleFuelType> FuelTypesInitializer()
        {
            var firstFuelType = new VehicleFuelType();
            firstFuelType.Id = 1;
            firstFuelType.Name = "Gaz";
            var secondFuelType = new VehicleFuelType();
            secondFuelType.Id = 2;
            secondFuelType.Name = "Benzyna";
            var thirdFuelType = new VehicleFuelType();
            thirdFuelType.Id = 3;
            thirdFuelType.Name = "Olej napędowy";
            var fuelTypesList = new List<VehicleFuelType>();
            fuelTypesList.Add(firstFuelType);
            fuelTypesList.Add(secondFuelType);
            fuelTypesList.Add(thirdFuelType);

            return fuelTypesList;
        }
        public static List<Event> EvntInitializer()
        {
            List<Event> listRefulings = new List<Event>();
            listRefulings.Add(new Event
            {
                Id = "1r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 900,
                CreatedDateTime = DateTime.Now,
                VehicleId = 10
            });
            listRefulings.Add(new Event
            {
                Id = "2r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 1000,
                CreatedDateTime = DateTime.Now,
                VehicleId = 10
            });
            listRefulings.Add(new Event
            {
                Id = "3r",
                IsActive = true,
                AmountOfFuel = 102,
                MeterStatus = 1100,
                CreatedDateTime = DateTime.Now,
                VehicleId = 10
            });

            return listRefulings;
        }
        public static List<Event> EventInitializerForStats()
        {
            List<Event> listRefulings = new List<Event>();
            listRefulings.Add(new Event
            {
                Id = "1r",
                IsActive = true,
                AmountOfFuel = 40,
                MeterStatus = 100,
                PriceForOneUnit = 2.39M,
                PriceForEvent = 95.60M,
                EventListId = 1,
                EventDate = new DateTime(2021, 1, 1),
                VehicleId = 10
            });
            listRefulings.Add(new Event
            {
                Id = "2r",
                IsActive = true,
                AmountOfFuel = 35,
                MeterStatus = 600,
                PriceForOneUnit = 2.33M,
                PriceForEvent = 81.55M,
                EventListId = 1,
                EventDate = new DateTime(2021, 1, 15),
                VehicleId = 10
            });
            listRefulings.Add(new Event
            {
                Id = "3r",
                IsActive = true,
                AmountOfFuel = 55,
                MeterStatus = 1100,
                PriceForOneUnit = 2.29M,
                PriceForEvent = 125.95M,
                EventListId = 1,
                EventDate = new DateTime(2021, 1, 20),
                VehicleId = 10
            });
            listRefulings.Add(new Event
            {
                Id = "4r",
                IsActive = true,
                AmountOfFuel = 55,
                MeterStatus = 1100,
                PriceForOneUnit = 0,
                PriceForEvent = 1400.00M,
                EventListId = 2,
                EventDate = new DateTime(2021, 1, 25),
                VehicleId = 10
            });
            return listRefulings;
        }
        public static List<VehicleEventsForListVm> VehicleEventsForListVmInitializer()
        {
            List<VehicleEventsForListVm> events = new List<VehicleEventsForListVm>(){
                new VehicleEventsForListVm()
            {
                VehicleId = 10,
                BurningFuelPerOneHundredKilometers = 24
            },
                new VehicleEventsForListVm()
            {
                VehicleId = 10,
                BurningFuelPerOneHundredKilometers = 20
            }, new VehicleEventsForListVm()
            {
                VehicleId = 10,
                BurningFuelPerOneHundredKilometers = 0
            },
            new VehicleEventsForListVm()
            {
                VehicleId = 10,
                BurningFuelPerOneHundredKilometers = 24.65M
            },
            new VehicleEventsForListVm()
            {
                VehicleId = 10,
                BurningFuelPerOneHundredKilometers = 0
            }};
            return events;
        }

    }
}
