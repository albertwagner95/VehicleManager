using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Mapping;
using VehicleManager.Application.Services.Helpers;
using VehicleManager.Application.ViewModels.Vehicle;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class NewEventVm : IMapFrom<Event>
    {
        public string Id { get; set; }
        public decimal AmountOfFuel { get; set; }
        public decimal PriceForEvent { get; set; }
        public decimal FuelPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal PriceForOneUnit { get; set; }
        public int MeterStatus { get; set; }
        public string PetrolStationName { get; set; } //optional
        public bool IsRefulingFull { get; set; }
        public string Varnings { get; set; }
        public decimal BurningFuelPerOneHoundredKilometeres { get; set; }
        public DateTime EventDate { get; set; }
        public ListForUserCarsForListVm UserCars { get; set; }
        public List<KindOfEventsListVm> EventsListVm { get; set; }
        public int EventsListId { get; set; }
        public ListFuelTypeForRefuelingForListVm VehicleFuelTypes { get; set; }
        public ListForUnitOfFuelForListVm UnitOfFuelForList { get; set; }
        public int FuelForRefuelingId { get; set; }
        public int VehicleId { get; set; }
        //public string CarHistoryId { get; set; }
        public int UnitOfFuelId { get; set; }
        public ListForUserCarsForListVm VehiclesList { get; set; }


        //helpers
        public int LastMeters { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewEventVm, Event>().ReverseMap();
        }

        public class NewRefuelingValidation : AbstractValidator<NewEventVm>
        {

            public NewRefuelingValidation()
            {
                RuleFor(x => x.MeterStatus).GreaterThan(a => a.LastMeters).WithMessage($"Aktualny przebieg, nie może być niższy od poprzedniego - edytuj przebieg pojazdu, lub wpisz inną wartość!");
                RuleFor(x => x.Varnings).MaximumLength(250).WithMessage("Maksymalna długość tekstu to 250 znaków!");
                RuleFor(x => x.MeterStatus).GreaterThan(0).WithMessage("Przebieg nie może być ujemny");
                RuleFor(x => x.PetrolStationName).MaximumLength(35).WithMessage("Maksymalna długość tekstu to 35 znaków!");

                RuleFor(x => x.VehicleId).GreaterThanOrEqualTo(1).WithMessage("Wybierz z listy!");
                RuleFor(x => x.EventsListId).GreaterThanOrEqualTo(1).WithMessage("Wybierz z listy!"); 
                RuleFor(x => x.FuelForRefuelingId).GreaterThanOrEqualTo(1).WithMessage("Wybierz z listy!"); 
                RuleFor(x => x.UnitOfFuelId).GreaterThanOrEqualTo(1).WithMessage("Wybierz z listy!"); 
                RuleFor(x => x.AmountOfFuel).GreaterThan(0.01M).WithMessage("Ilość jednostek paliwa, nie może być mniejsza niż 0.01!"); 
                RuleFor(x => x.PriceForOneUnit).GreaterThan(0.01M).WithMessage("Cena za jednostkę paliwa, nie może być mniejsza niż 0.01!"); 
                RuleFor(x => x.PriceForEvent).GreaterThanOrEqualTo(0).WithMessage("Koszt zdarzenia, nie może być mniejszy od 0 zł.");   
            }

        }
    }
}
