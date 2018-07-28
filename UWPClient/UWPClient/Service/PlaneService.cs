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
	public class PlaneService : IPlaneService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/plane");

		public PlaneService()
		{
			client = new HttpClient();
		}

		public Task Create(Plane f)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<Plane> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<Plane[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			Plane[] planes = JsonConvert.DeserializeObject<Plane[]>(temp);
			return planes;
		}

		public Task Update(int id, Plane f)
		{
			throw new NotImplementedException();
		}
	}
}
