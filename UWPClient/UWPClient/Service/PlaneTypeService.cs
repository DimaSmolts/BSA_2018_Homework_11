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
	class PlaneTypeService : IPlaneTypeService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/planetype");

		public PlaneTypeService()
		{
			client = new HttpClient();
		}


		public Task Create(PlaneType pt)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<PlaneType> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<PlaneType[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			PlaneType[] pts = JsonConvert.DeserializeObject<PlaneType[]>(temp);
			return pts;
		}

		public Task Update(int id, PlaneType pt)
		{
			throw new NotImplementedException();
		}
	}
}
