using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;
using UWPClient.Model.InputModels;
using UWPClient.Service.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace UWPClient.Service
{
	public class TicketService : ITicketService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/ticket");

		public TicketService()
		{
			client = new HttpClient();
		}

		public async Task Create(InputTickets t)
		{
			await client.PostAsJsonAsync(path, t);
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<Ticket> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<Ticket[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			Ticket[] tickets = JsonConvert.DeserializeObject<Ticket[]>(temp);
			return tickets;
		}

		public async Task Update(int id, InputTickets t)
		{
			string temp = path.ToString() + "/" + id.ToString();

			await client.PutAsJsonAsync(temp, t);
		}
	}
}
