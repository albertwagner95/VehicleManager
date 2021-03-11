using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class NewVehicleVm : IMapFrom<Domain.Model.VehicleModels.Vehicle>
    {
        public int Id { get; set; }
        [MaxLength(17)]
        public string Vin { get; set; }
        public int Millage { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfFirstRegistration { get; set; }
        public string Model { get; set; }
        public bool IsRegisterdInPoland { get; set; }
        [MaxLength(8)]
        public string RegistrationNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProductionDate { get; set; }
        public int EnginePower { get; set; } //kw
        public int EngineCapacity { get; set; }
        public int PermissibleGrossWeight { get; set; }
        public int Capacity { get; set; }
        public int OwnWeight { get; set; }
        public int YearHelper { get; set; }
        public bool IsGasInstalation { get; set; }
        public string ApplicationUserID { get; set; }
        public int VehicleFuelTypeId { get; set; }
        public int VehicleBrandNameId { get; set; }
        public int VehicleTypeId { get; set; }
        public List<VehicleFuelTypeVm> VehicleFuelTypes { get; set; }
        public List<VehicleBrandNameVm> VehicleBrandNames { get; set; }
        public List<VehicleTypeVm> VehicleTypes { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewVehicleVm, Domain.Model.VehicleModels.Vehicle>().ReverseMap();
        }

        public class NewVehicleValidation : AbstractValidator<NewVehicleVm>
        {
            public NewVehicleValidation()
            {

                RuleFor(v => v.Id).NotNull();
                RuleFor(v => v.Vin).Length(17).WithMessage("Numer VIN powinien składać się z 17 znaków");
                RuleFor(v => v.Vin).Matches("[a-zA-Z0-9]{11}[0-9]{6}").WithMessage("6 ostatnich znaków, może być tylko cyframi");
                RuleFor(v => v.YearHelper).GreaterThan(1799).WithMessage("Rok produkcji nie może być mniejszy niż 1799r");
                RuleFor(v => v.YearHelper).LessThanOrEqualTo(a => a.DateOfFirstRegistration.Year).WithMessage("Data pierwszej rejestracji nie może być wcześniejsza niż rok produkcji");
                RuleFor(v => v.YearHelper).LessThanOrEqualTo(DateTime.Today.Year).WithMessage($"Rok produkcji nie może być wyższa od {DateTime.Today.Year}") ;
                RuleFor(v => v.OwnWeight).LessThan(a => a.PermissibleGrossWeight).WithMessage("Masa własna nie może być większa od DMC");
                RuleFor(v => v.OwnWeight).GreaterThan(10).WithMessage("Masa własna nie może mieć mniej niż 2 znaki");
                RuleFor(v => v.PermissibleGrossWeight).GreaterThan(10).WithMessage("Masa własna nie może mieć mniej niż 2 znaki");
                
                RuleFor(v => v.ApplicationUserID).NotNull();
                RuleFor(v => v.EngineCapacity).GreaterThan(0).WithMessage("Pojemność silnika nie może być mniejsza od 1 cm^3");
                RuleFor(v => v.EnginePower).GreaterThan(0).WithMessage("Moc silnika nie może być mniejsza od 1 kW");
                RuleFor(v => v.Millage).NotEmpty().WithMessage("Wartość wymagana");
                RuleFor(v => v.Millage).GreaterThan(0).WithMessage("Przebieg nie może być mniejszy niż 1 km");
                RuleFor(v => v.RegistrationNumber).MaximumLength(8).WithMessage("Maksymalna długość numeru rejestracyjnego wynosi 8");

                RuleFor(v => v.VehicleTypeId).NotNull().WithMessage("Pole nie może być puste"); 
                RuleFor(v => v.VehicleBrandNameId).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.VehicleBrandNameId).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.Model).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.Vin).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.RegistrationNumber).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.Millage).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.DateOfFirstRegistration).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.YearHelper).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.EnginePower).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.EngineCapacity).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.PermissibleGrossWeight).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.OwnWeight).NotNull().WithMessage("Pole nie może być puste.");
                RuleFor(v => v.VehicleFuelTypeId).NotNull().WithMessage("Pole nie może być puste."); 
            }
        }
    }
}

