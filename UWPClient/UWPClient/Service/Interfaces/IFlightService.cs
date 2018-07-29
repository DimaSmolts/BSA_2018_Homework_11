using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface IFlightService
	{
		Task<Flight> Get();
		Task<Flight[]> GetAll();
		Task Delete(int id);
		Task Create(Flight f);
		Task Update(int id, Flight f);
	}
}
