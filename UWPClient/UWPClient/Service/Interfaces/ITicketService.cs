using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;

namespace UWPClient.Service.Interfaces
{
	public interface ITicketService
	{
		Task<Ticket> Get();
		Task<Ticket[]> GetAll();
		Task Delete(int id);
		Task Create(Ticket t);
		Task Update(int id, Ticket t);
	}
}
