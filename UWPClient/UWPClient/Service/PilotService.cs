using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Service.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using UWPClient.Model;

namespace UWPClient.Service
{
	class PilotService : IPilotService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/pilot");

		public PilotService()
		{
			client = new HttpClient();
		}

		public Task Create(Pilot pi)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<Pilot> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<Pilot[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);
			var temp = await response.Content.ReadAsStringAsync();
			Pilot[] pilots = JsonConvert.DeserializeObject<Pilot[]>(temp);
			return pilots;
		}

		public Task Update(int id, Pilot pi)
		{
			throw new NotImplementedException();
		}
	}
}
