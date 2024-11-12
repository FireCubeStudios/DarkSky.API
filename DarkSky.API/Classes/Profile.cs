using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API.Classes
{
	public class Profile
	{
		public int DID { get; }
		public string Handle { get; }
		public string DisplayName { get; }
		public Uri Avatar { get; }
		public Uri Banner { get; }
		public int Followers { get; }
		public int Following {  get; }
		public int PostsCount { get; }
		public DateTime CreatedAt { get; }

		public Profile(int did, string handle, string displayName, string avatar, string banner,
						int followersCount, int followsCount, int postsCount, string createdAt)
		{
			DID = did;
			Handle = handle;
			DisplayName = displayName;
			Avatar = new Uri(avatar);
			Banner = new Uri(banner);
			Followers = followersCount;
			Following = followsCount;
			PostsCount = postsCount;
			CreatedAt = DateTime.Parse(createdAt);
		}
	}
}
