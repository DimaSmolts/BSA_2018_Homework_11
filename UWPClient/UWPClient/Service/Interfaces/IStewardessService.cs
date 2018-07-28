using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface IStewardessService
	{
		Task<Stewardess> Get();
		Task<Stewardess[]> GetAll();
		Task Delete(int id);
		Task Create(Stewardess s);
		Task Update(int id, Stewardess s);
	}
}
