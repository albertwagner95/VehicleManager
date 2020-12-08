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
    public class NewRefulingVm : IMapFrom<Refueling>
    {
        public string Id { get; set; }
        public decimal AmountOfFuel { get; set; }
        public decimal FuelPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal PriceForOneUnit { get; set; }
        public int MeterStatus { get; set; }
        public string PetrolStationName { get; set; } //optional
        public bool IsRefulingFull { get; set; }
        public string Varnings { get; set; }
        public decimal BurningFuelPerOneHoundredKilometeres { get; set; }
        public ListForUserCarsForListVm UserCars { get; set; }
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
            profile.CreateMap<NewRefulingVm, Refueling>().ReverseMap();
        }

        public class NewRefuelingValidation : AbstractValidator<NewRefulingVm>
        {

            public NewRefuelingValidation()
            {
                RuleFor(x => x.MeterStatus).GreaterThan(a => a.LastMeters).WithMessage($"Aktualny przebieg, nie może być niższy od poprzedniego - edytuj przebieg pojazdu, lub wpisz inną wartość!");
                RuleFor(x => x.Varnings).MaximumLength(250).WithMessage("Maksymalna długość tekstu to 250 znaków!");
                RuleFor(x => x.MeterStatus).GreaterThan(0).WithMessage("Przebieg nie może być ujemny");
                RuleFor(x => x.PetrolStationName).MaximumLength(35).WithMessage("Maksymalna długość tekstu to 35 znaków!");
                RuleFor(x => x.AmountOfFuel).NotNull().WithMessage("Wartość wymagana");
                RuleFor(x => x.MeterStatus).NotNull().WithMessage("Wartość wymagana");
                RuleFor(x => x.PriceForOneUnit).NotNull().WithMessage("Wartość wymagana");
                RuleFor(x => x.VehicleId).NotNull().WithMessage("Wartość wymagana");
                RuleFor(x => x.UnitOfFuelId).NotNull().WithMessage("Wartość wymagana");
                RuleFor(x => x.AmountOfFuel).NotEmpty().WithMessage("Wartość wymagana");
                RuleFor(x => x.MeterStatus).NotEmpty().WithMessage("Wartość wymagana");
                RuleFor(x => x.PriceForOneUnit).NotEmpty().WithMessage("Wartość wymagana");
                RuleFor(x => x.VehicleId).NotEmpty().WithMessage("Wartość wymagana");
                RuleFor(x => x.UnitOfFuelId).NotEmpty().WithMessage("Wartość wymagana");
                RuleFor(x => x.AmountOfFuel).GreaterThan(0).WithMessage("Ilość paliwa, nie może być ujemna!");
            }

        }
    }
}
