using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;
using UWPClient.Model.InputModels;

namespace UWPClient.Service.Interfaces
{
	public interface IPlaneService
	{
		Task<Plane> Get();
		Task<Plane[]> GetAll();
		Task Delete(int id);
		Task Create(InputPlane f);
		Task Update(int id, InputPlane f);
	}
}
