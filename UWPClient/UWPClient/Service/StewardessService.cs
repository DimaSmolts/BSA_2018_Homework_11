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
	public class StewardessService : IStewardessService
	{

		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/stewardess");

		public StewardessService()
		{
			client = new HttpClient();
		}

		public Task Create(Stewardess s)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<Stewardess> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<Stewardess[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			Stewardess[] stewardesses = JsonConvert.DeserializeObject<Stewardess[]>(temp);
			return stewardesses;
		}

		public Task Update(int id, Stewardess s)
		{
			throw new NotImplementedException();
		}
	}
}
