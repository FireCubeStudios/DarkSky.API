using DarkSky.API.ATProtocol;
using DarkSky.API.Classes;
using System;
using System.Collections.Generic;
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

			return await JsonSerializer.DeserializeAsync<Profile>(await response.Content.ReadAsStreamAsync());
		}
	}
}
