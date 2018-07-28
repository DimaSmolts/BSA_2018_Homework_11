using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Model;
using UWPClient.Service.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace UWPClient.Service
{
	public class FlightService : IFlightService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/flight");

		public FlightService()
		{
			client = new HttpClient();
		}

		public Task Create(Flight f)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() +"/"+ id.ToString()));			
		}

		public Task<Flight> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<Flight[]> GetAll()
		{						
			client = new HttpClient();
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			Flight[] flights = JsonConvert.DeserializeObject<Flight[]>(temp);
			return flights;
		}

		public Task Update(int id, Flight f)
		{
			throw new NotImplementedException();
		}
	}
}
