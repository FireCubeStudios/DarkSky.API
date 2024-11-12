using DarkSky.API.ATProtocol;
using DarkSky.API.Classes;
using DarkSky.API.Helpers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API.Services
{
	public class FeedService
	{

		/*
		 * Get a view of an actor's 'author feed' (post and reposts by the author).
		 * https://docs.bsky.app/docs/api/app-bsky-feed-get-author-feed
		 */
		public static async Task<List<Post>> GetAuthorFeed(string actor)
		{
			var response = await Client.ATProtoClient.GetAsync($"{Constants.GET_AUTHOR_FEED_ENDPOINT}?actor={actor}");
			response.EnsureSuccessStatusCode();
			return await FeedParser.ParseFeedAsync(await response.Content.ReadAsStreamAsync());
		}

		/*
		 * Get a view of the authenticated account's home timeline.
		 * https://docs.bsky.app/docs/api/app-bsky-feed-get-timeline
		 */
		public static async Task GetTimeline()
		{

		}
	}
}
