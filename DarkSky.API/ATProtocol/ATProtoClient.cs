﻿using System;
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
		public AuthSession? Session { get; }

	   /* 
		* Constructor for authenticated ATProtoClient
		* Set ATProtoClient to use AccessToken in header for future HTTP requests
		* If there is a PDS use that url for requests
		*/
		public ATProtoClient(AuthSession session)
		{
			Session = session;
			this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
			BaseAddress = new Uri(Session.PDSUrl ?? Constants.BASE_URL); 
		}

		// Constructor for non-authenticated ATProtoClient
		// Used mainly to get authentication service
		public ATProtoClient()
		{
			BaseAddress = new Uri(Constants.BASE_URL); // Use BASE_URL for requests (https://bsky.social)
		}
	}
}
