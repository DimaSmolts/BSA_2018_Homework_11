using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Model
{
	public class Ticket
	{
		public int Id { get; set; }
		public decimal Price { get; set; }
		public Flight FlightNum { get; set; }
	}
}
