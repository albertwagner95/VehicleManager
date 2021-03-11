using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class CarHistoryForListVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int VehicleId { get; set; }
        public string RefulingRef { get; set; }
        public string EventRef { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime EventDate { get; set; }
        public int MeterStatus { get; set; }
        public decimal AmountOfFuel { get; set; }
        public string RefuelingId { get; set; }
        public string EventId { get; set; }
        public string ApplicationUserID { get; internal set; }
        public decimal RefuelingPrice { get; internal set; }
    }
}
