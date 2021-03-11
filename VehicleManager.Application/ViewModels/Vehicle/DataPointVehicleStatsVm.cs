using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VehicleManager.Application.ViewModels.Vehicle
{
	[DataContract]
	public class DataPointVehicleStatsVm
	{
		public DataPointVehicleStatsVm(string  label, double y)
		{
			this.Label = label;
			this.Y = y;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string Label { get; set; }

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public double? Y = null;
	}
}
