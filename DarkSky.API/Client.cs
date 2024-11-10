using DarkSky.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API
{
	public class Client
	{
		private HttpClient httpClient = new HttpClient();

		public async void Login(String Username, String AppPassword)
		{
			httpClient = await new AppPasswordService().LoginAsync(Username, AppPassword);
		}
	}
}
