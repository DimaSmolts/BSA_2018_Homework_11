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
	public class CrewService : ICrewService
	{
		private HttpClient client;
		private Uri path = new Uri("http://localhost:3111/api/crew");

		public CrewService()
		{
			client = new HttpClient();
		}

		public Task Create(Crew f)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await client.DeleteAsync(new Uri(path.ToString() + "/" + id.ToString()));
		}

		public Task<Crew> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<Crew[]> GetAll()
		{
			var response = await client.GetAsync(path).ConfigureAwait(false);

			var temp = await response.Content.ReadAsStringAsync();
			Crew[] crews = JsonConvert.DeserializeObject<Crew[]>(temp);
			return crews;
		}

		public Task Update(int id, Crew f)
		{
			throw new NotImplementedException();
		}
	}
}
