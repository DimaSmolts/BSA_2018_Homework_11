using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;
using UWPClient.Model.InputModels;

namespace UWPClient.Service.Interfaces
{
	public interface ITakeOffService
	{
		Task<TakeOff> Get();
		Task<TakeOff[]> GetAll();
		Task Delete(int id);
		Task Create(InputTakeOff f);
		Task Update(int id, InputTakeOff f);
	}
}
