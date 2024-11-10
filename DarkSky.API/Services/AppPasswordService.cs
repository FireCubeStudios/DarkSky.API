using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DarkSky.API.Services
{
	public class AppPasswordService
	{
		private String? refreshToken;
		private String? accessToken;

		public async Task<HttpClient> LoginAsync(string username, string password)
		{
			HttpClient httpClient = new HttpClient
			{
				BaseAddress = new Uri(Constants.BaseUrl)
			};
			var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

			// Send a login request (change the endpoint if needed)
			var response = await httpClient.GetAsync("/xrpc/com.atproto.server.createSession");
			response.EnsureSuccessStatusCode();

			// Extract token from response
			using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
			accessToken = doc.RootElement.GetProperty("accessJwt").GetString();
			refreshToken = doc.RootElement.GetProperty("refreshJwt").GetString();

			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			return httpClient;
		}
	}
}
