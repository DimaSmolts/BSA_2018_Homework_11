using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface ITakeOffService
	{
		Task<TakeOff> Get();
		Task<TakeOff[]> GetAll();
		Task Delete(int id);
		Task Create(TakeOff f);
		Task Update(int id, TakeOff f);
	}
}
