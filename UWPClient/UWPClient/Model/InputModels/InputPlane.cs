using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClient.Model.InputModels
{
    public class InputPlane
    {
		public string Name { get; set; }
		public int Type { get; set; }
		public DateTime Made { get; set; }
		public TimeSpan Exploitation { get; set; }
	}
}
