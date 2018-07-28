using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model
{
	public class Flight
	{
		public int FlightNum { get; set; }
		public string DeperturePlace { get; set; }
		public DateTime DepartureTime { get; set; }
		public string ArrivalPlace { get; set; }
		public DateTime ArrivalTime { get; set; }

	}
}
