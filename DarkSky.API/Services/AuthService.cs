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
	public class AuthService
	{
		private const string AUTH_SESSION_ENDPOINT = "/xrpc/com.atproto.server.createSession";
		private const string ACCESS_TOKEN = "accessJwt";
		private const string REFRESH_TOKEN = "refreshJwt";
		private const string ACCOUNT_HANDLE = "handle";
		private const string ACCOUNT_DID = "did";

		private string? RefreshToken;
		private string? AccessToken;
		private string? AccountHandle;
		private string? AccountDid;

		public async Task<HttpClient> LoginAsync(string username, string password)
		{
			HttpClient httpClient = new HttpClient
			{
				BaseAddress = new Uri(Constants.BaseUrl)
			};
			var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

			// Send a login request
			var response = await httpClient.GetAsync(AUTH_SESSION_ENDPOINT);
			response.EnsureSuccessStatusCode();

			// Extract token from response
			using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
			AccessToken = doc.RootElement.GetProperty(ACCESS_TOKEN).GetString();
			RefreshToken = doc.RootElement.GetProperty(REFRESH_TOKEN).GetString();
			AccountHandle = doc.RootElement.GetProperty(ACCOUNT_HANDLE).GetString();
			AccountDid = doc.RootElement.GetProperty(ACCOUNT_DID).GetString();

			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

			return httpClient;
		}
	}
}
