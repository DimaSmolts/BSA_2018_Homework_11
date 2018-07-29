using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClient.Service.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using UWPClient.Model;
using UWPClient.Model.InputModels;

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

		public async Task Create(InputTakeOff f)
		{
			await client.PostAsJsonAsync(path, f);
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

		public async Task Update(int id, InputTakeOff f)
		{
			string temp = path.ToString() + "/" + id.ToString();

			await client.PutAsJsonAsync(temp, f);
		}
	}
}
