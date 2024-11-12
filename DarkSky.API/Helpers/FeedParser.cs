using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using DarkSky.API.Classes;
using System.Diagnostics;

namespace DarkSky.API.Helpers
{
	public class FeedParser
	{
		/*
		 * Parse the JSON of a Feed array. 
		 * The array contains objects which contains a "post" object
		 * Additionally the object can contain "reply" and "reason" objects besides "post"
		 * 
		 * https://docs.bsky.app/docs/api/app-bsky-feed-get-feed
		 */
		public static async Task<List<Post>> ParseFeedAsync(Stream json)
		{
			List<Post> posts = new();
			using (JsonDocument doc = await JsonDocument.ParseAsync(json))
			{
				// Loop through each element in the "feed" array
				foreach (JsonElement item in doc.RootElement.GetProperty("feed").EnumerateArray())
				{
					Debug.WriteLine(item.GetProperty("post"));
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					};
					posts.Add(item.GetProperty("post").Deserialize<Post>(options));
				}
			}
			return posts;
		}
	}
}
