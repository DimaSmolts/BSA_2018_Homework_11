using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model
{
	public class Pilot
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime Birth { get; set; }
		public TimeSpan Experience { get; set; }
	}
}
