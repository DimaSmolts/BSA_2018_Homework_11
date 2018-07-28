using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface IPlaneService
	{
		Task<Plane> Get();
		Task<Plane[]> GetAll();
		Task Delete(int id);
		Task Create(Plane f);
		Task Update(int id, Plane f);
	}
}
