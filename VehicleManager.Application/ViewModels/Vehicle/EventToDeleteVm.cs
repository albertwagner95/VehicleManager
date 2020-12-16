using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class EventToDeleteVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
