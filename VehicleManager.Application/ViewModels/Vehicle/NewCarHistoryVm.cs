using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class NewCarHistoryVm:IMapFrom<CarHistory>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RefulingRef { get; set; }
        public int VehicleId { get; set; }
        public string ApplicationUserID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedById { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCarHistoryVm, CarHistory>().ReverseMap();
        }
    }
}