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

		private AuthService authService = new AuthService();
		public async Task Login(String Username, String AppPassword)
		{
			httpClient = await authService.LoginAsync(Username, AppPassword);
		}

		public async Task GetCurrentUser()
		{

		}
	}
}
