using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface ICrewService
	{
		Task<Crew> Get();
		Task<Crew[]> GetAll();
		Task Delete(int id);
		Task Create(Crew f);
		Task Update(int id, Crew f);
	}
}
