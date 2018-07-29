using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface IPilotService
	{
		Task<Pilot> Get();
		Task<Pilot[]> GetAll();
		Task Delete(int id);
		Task Create(Pilot pi);
		Task Update(int id, Pilot pi);
	}
}
