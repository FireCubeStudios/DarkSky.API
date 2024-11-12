using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API.Classes
{
	public class Profile
	{
		public string DID { get; }
		public string Handle { get; }
		public string DisplayName { get; }
		public string Description { get;  }
		public Uri Avatar { get; }
		public Uri Banner { get; }
		public int Followers { get; }
		public int Following {  get; }
		public int PostsCount { get; }
		public DateTime CreatedAt { get; }

		public Profile(string did, string handle, string displayName, string avatar, string createdAt, string description, string banner, int followersCount, int followsCount, int postsCount)
		{
			DID = did;
			Handle = handle;
			DisplayName = displayName;
			Description = description;
			Avatar = new Uri(avatar);
			Banner = new Uri(banner);
			Followers = followersCount;
			Following = followsCount;
			PostsCount = postsCount;
			CreatedAt = DateTime.Parse(createdAt);
		}
	}
}
