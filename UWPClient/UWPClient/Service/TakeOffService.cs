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
	public class TakeOffService : ITakeOffService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/takeoff");

		public TakeOffService()
		{
			client = new HttpClient();
		}

		public Task Create(TakeOff f)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<TakeOff> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<TakeOff[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			TakeOff[] takeoffs = JsonConvert.DeserializeObject<TakeOff[]>(temp);
			return takeoffs;
		}

		public Task Update(int id, TakeOff f)
		{
			throw new NotImplementedException();
		}
	}
}
