using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;
using UWPClient.Model.InputModels;

namespace UWPClient.Service.Interfaces
{
	public interface ITicketService
	{
		Task<Ticket> Get();
		Task<Ticket[]> GetAll();
		Task Delete(int id);
		Task Create(InputTickets t);
		Task Update(int id, InputTickets t);
	}
}
