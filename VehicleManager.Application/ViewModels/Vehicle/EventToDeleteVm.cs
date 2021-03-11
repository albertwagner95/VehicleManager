using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class EventToDeleteVm : IMapFrom<Event>
    {
        public string Id { get; set; }
        public DateTime? CreatedDateTime { get; set; }
         
    }
}
