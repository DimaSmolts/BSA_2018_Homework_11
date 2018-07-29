using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;
using UWPClient.Model.InputModels;

namespace UWPClient.Service.Interfaces
{
	public interface ICrewService
	{
		Task<Crew> Get();
		Task<Crew[]> GetAll();
		Task Delete(int id);
		Task Create(InputCrew f);
		Task Update(int id, InputCrew f);
	}
}
