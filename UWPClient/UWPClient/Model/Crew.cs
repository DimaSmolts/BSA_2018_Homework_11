using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model
{
	public class Crew
	{
		public int Id { get; set; }
		public Pilot PilotId { get; set; }
		public Stewardess[] StewardessIds { get; set; }
	}
}
