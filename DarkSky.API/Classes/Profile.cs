using DarkSky.API.ATProtocol;
using DarkSky.API.Helpers;
using DarkSky.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DarkSky.API.Classes
{
	public record Profile(
		string DID,
		string Handle,
		string DisplayName,
		string Description,
		Uri Avatar,
		Uri Banner,
		int FollowersCount,
		int FollowsCount,
		int PostsCount,
		DateTime CreatedAt
	){
		public async Task<List<Post>> GetProfileFeedAsync() => await FeedService.GetAuthorFeed(DID);
	}
}
