using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model
{
	public class PlaneType
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public int Places { get; set; }
		public int CarryCapacity { get; set; }
	}
}
