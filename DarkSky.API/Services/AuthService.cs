using DarkSky.API.ATProtocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		private const string ACCESS_TOKEN = "accessJwt";
		private const string REFRESH_TOKEN = "refreshJwt";
		private const string ACCOUNT_HANDLE = "handle";
		private const string ACCOUNT_DID = "did";
		private const string ACCOUNT_PDS_URL = "serviceEndpoint";

		/*
		 * Refresh an existing session using the refresh token
		 * https://docs.bsky.app/docs/api/com-atproto-server-refresh-session
		 */
		public async Task<ATProtoClient> RefreshAsync(ATProtoClient client)
		{
			AuthSession session;

			client.SetRefreshTokenHeader(); // Set refresh token as authorisation bearer
			var response = await client.PostAsync(Constants.REFRESH_SESSION_ENDPOINT, null);
			response.EnsureSuccessStatusCode();

			// Extract data from response
			using (JsonDocument json = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync()))
			{
				JsonElement root = json.RootElement;
				session = new(
					root.GetProperty(ACCOUNT_DID).GetString(),
					root.GetProperty(ACCOUNT_HANDLE).GetString(),
					root.GetProperty("didDoc").GetProperty("service")[0].GetProperty("serviceEndpoint").GetString(),
					root.GetProperty(ACCESS_TOKEN).GetString(),
					root.GetProperty(REFRESH_TOKEN).GetString()
				);
			}

			return new ATProtoClient(session);
		}

		/*
		 * Create a new session using user credentials
		 * https://docs.bsky.app/docs/api/com-atproto-server-create-session
		 */
		public async Task<ATProtoClient> LoginAsync(string username, string password)
		{
			ATProtoClient ATProtoClient = new ATProtoClient();
			AuthSession session;

			// com.atproto.server.createSession JSON body payload
			// identifier = username/handle (firecube.bsky.social)
			string payload = JsonSerializer.Serialize(
				new
				{
					identifier = username,
					password
				}
			);
			var content = new StringContent(payload, Encoding.UTF8, "application/json");

			// Send a login request
			var response = await ATProtoClient.PostAsync(Constants.CREATE_SESSION_ENDPOINT, content);
			response.EnsureSuccessStatusCode();

			// Extract data from response
			using (JsonDocument json = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync()))
			{
				JsonElement root = json.RootElement;
				session = new(
					root.GetProperty(ACCOUNT_DID).GetString(),
					root.GetProperty(ACCOUNT_HANDLE).GetString(),
					root.GetProperty("didDoc").GetProperty("service")[0].GetProperty("serviceEndpoint").GetString(),
					root.GetProperty(ACCESS_TOKEN).GetString(),
					root.GetProperty(REFRESH_TOKEN).GetString()
				);
			}
			
			return new ATProtoClient(session);
		}
	}
}
