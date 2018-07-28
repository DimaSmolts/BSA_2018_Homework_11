using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface IPlaneTypeService
	{
		Task<PlaneType> Get();
		Task<PlaneType[]> GetAll();
		Task Delete(int id);
		Task Create(PlaneType pt);
		Task Update(int id, PlaneType pt);		
	}
}
