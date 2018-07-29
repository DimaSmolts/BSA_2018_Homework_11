using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model
{
	public class TakeOff
	{
		public int Id { get; set; }
		public Flight FlightNum { get; set; }
		public DateTime Date { get; set; }
		public Crew CrewId { get; set; }
		public Plane PlaneId { get; set; }
	}
}
