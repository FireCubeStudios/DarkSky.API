using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API
{
	public static class Constants
	{
		public const string BASE_URL = "https://bsky.social";

		public const string AUTH_SESSION_ENDPOINT = "/xrpc/com.atproto.server.createSession";
		public const string GET_PROFILE_ENDPOINT = "/xrpc/app.bsky.actor.getProfile";
	}
}
