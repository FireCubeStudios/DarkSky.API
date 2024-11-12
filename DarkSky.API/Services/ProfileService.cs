using DarkSky.API.ATProtocol;
using DarkSky.API.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DarkSky.API.Services
{
	public class ProfileService
	{
		private ATProtoClient ATProtoClient;

		public ProfileService(ATProtoClient ATProtoClient)
		{
			this.ATProtoClient = ATProtoClient;
		}

		// Get a profile using the DID or handle of the profile
		// https://docs.bsky.app/docs/api/app-bsky-actor-get-profile
		public async Task<Profile> GetProfileAsync(string actor)
		{
			var response = await ATProtoClient.GetAsync($"{Constants.GET_PROFILE_ENDPOINT}?actor={actor}");
			response.EnsureSuccessStatusCode();

			/// This did not work
			///return await JsonSerializer.DeserializeAsync<Profile>(await response.Content.ReadAsStreamAsync());
			
			JsonElement json = await JsonSerializer.DeserializeAsync<JsonElement>(await response.Content.ReadAsStreamAsync());
			string did = json.GetProperty("did").GetString();
			string handle = json.GetProperty("handle").GetString();
			string displayName = json.GetProperty("displayName").GetString();
			string description = json.GetProperty("description").GetString();
			string avatar = json.GetProperty("avatar").GetString();
			string banner = json.GetProperty("banner").GetString();
			int followersCount = json.GetProperty("followersCount").GetInt32();
			int followsCount = json.GetProperty("followsCount").GetInt32();
			int postsCount = json.GetProperty("postsCount").GetInt32();
			string createdAt = json.GetProperty("createdAt").GetString();

			return new Profile(did, handle, displayName, avatar, createdAt, description, banner, followersCount, followsCount, postsCount);
		}
	}
}
