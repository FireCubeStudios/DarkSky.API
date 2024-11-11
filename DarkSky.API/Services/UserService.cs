using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API.Services
{
	public class UserService
	{
		private HttpClient httpClient;

		public UserService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

	}
}
