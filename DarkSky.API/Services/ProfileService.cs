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

		// Get a profile using the DID or handle of the profile
		// https://docs.bsky.app/docs/api/app-bsky-actor-get-profile
		public static async Task<Profile> GetProfileAsync(string actor)
		{
			var response = await Client.ATProtoClient.GetAsync($"{Constants.GET_PROFILE_ENDPOINT}?actor={actor}");
			response.EnsureSuccessStatusCode();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			return await JsonSerializer.DeserializeAsync<Profile>(await response.Content.ReadAsStreamAsync(), options);
		}
	}
}
