using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API.ATProtocol
{
	public class ATProtoClient : HttpClient
	{
		public AuthSession Session
		{
			get => Session;
			set
			{
				Session = value;
				// Set ATProtoClient to use AccessToken in header for future HTTP requests
				if (Session is not null)
				{
					this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
					// If there is a PDS use that url from now on for requests
					BaseAddress = new Uri(Session.PDSUrl ?? Constants.BASE_URL);
				}
			}
		}

		public ATProtoClient()
		{
			BaseAddress = new Uri(Constants.BASE_URL); // Initially use BASE_URL for requests (https://bsky.social)
		}
	}
}
