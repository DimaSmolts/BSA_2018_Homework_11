using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model.InputModels
{
    public class InputTakeOff
    {
		public int FlightNum { get; set; }
		public DateTime Date { get; set; }
		public int CrewId { get; set; }
		public int PlaneId { get; set; }
	}
}
