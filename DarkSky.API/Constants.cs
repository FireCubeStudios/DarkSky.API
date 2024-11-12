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

		public const string CREATE_SESSION_ENDPOINT = "/xrpc/com.atproto.server.createSession";
		public const string REFRESH_SESSION_ENDPOINT = "/xrpc/com.atproto.server.refreshSession";

		public const string GET_PROFILE_ENDPOINT = "/xrpc/app.bsky.actor.getProfile";

		public const string GET_FEED_ENDPOINT = "/xrpc/app.bsky.feed.getFeed";
		public const string GET_AUTHOR_FEED_ENDPOINT = "/xrpc/app.bsky.feed.getAuthorFeed";
		public const string GET_TIMELINE_ENDPOINT = "/xrpc/app.bsky.feed.getTimeline";
	}
}
