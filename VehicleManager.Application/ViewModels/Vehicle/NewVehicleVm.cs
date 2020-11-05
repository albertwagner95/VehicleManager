using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class NewVehicleVm : IMapFrom<Domain.Model.Vehicle>
    {
        public int Id { get; set; }
        [MaxLength(17)]
        public string Vin { get; set; }
        public int? Millage { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfFirstRegistration { get; set; }
        public string Model { get; set; }
        public bool IsRegisterdInPoland { get; set; }
        public string RegistrationNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProductionDate { get; set; }
        public uint EnginePower { get; set; } //kw
        public uint EngineCapacity { get; set; }
        public uint PermissibleGrossWeight { get; set; }
        public uint Capacity { get; set; }
        public uint OwnWeight { get; set; }
        public int YearHelper { get; set; }
        public string ApplicationUserID { get; set; }
        public int VehicleFuelTypeId { get; set; }
        public int VehicleBrandNameId { get; set; }
        public int VehicleTypeId { get; set; }
        public List<VehicleFuelTypeVm> VehicleFuelTypes { get; set; }
        public List<VehicleBrandNameVm> VehicleBrandNames { get; set; }
        public List<VehicleTypeVm> VehicleTypes { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewVehicleVm, Domain.Model.Vehicle>().ReverseMap();
        }

        public class NewVehicleValidation : AbstractValidator<NewVehicleVm>
        {
            public NewVehicleValidation()
            {
                
                RuleFor(v => v.Id).NotNull(); 
                RuleFor(v => v.Vin).Length(17).WithMessage("Numer VIN powinien składać się z 17 znaków");
                RuleFor(v => v.Vin).Matches("[a-zA-Z0-9]{11}[0-9]{6}").WithMessage("6 ostatnich znaków, może być tylko cyframi");
                
                RuleFor(v => v.YearHelper).LessThanOrEqualTo(a => a.DateOfFirstRegistration.Year).WithMessage("Data pierwszej rejestracji nie może być wcześniejsza niż rok produkcji");
                
                RuleFor(v => v.ApplicationUserID).NotNull();

                RuleFor(v => v.Model).NotNull();
                RuleFor(v => v.Millage).NotEmpty();
                RuleFor(v => v.Millage).GreaterThan(0);
                RuleFor(v => v.RegistrationNumber).MaximumLength(8).WithMessage("Maksymalna długość numeru rejestracyjnego wynosi 8");
            }
        }
    }
}

