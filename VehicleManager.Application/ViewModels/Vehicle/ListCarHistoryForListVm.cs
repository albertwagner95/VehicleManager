using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class ListCarHistoryForListVm
    {
        public List<CarHistoryForListVm> CarHistoryList { get; set; }
        public int VehicleId { get; set; }
        public ListForUserCarsForListVm UserCars { get; set; } 
    }
}
