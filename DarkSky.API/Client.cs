using DarkSky.API.ATProtocol;
using DarkSky.API.Classes;
using DarkSky.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API
{
	public class Client
	{
		private ATProtoClient ATProtoClient = new ATProtoClient();
		private AuthService authService = new AuthService();
		private ProfileService profileService;

		public async Task LoginAsync(String Username, String AppPassword)
		{
			ATProtoClient = await authService.LoginAsync(Username, AppPassword);
			profileService = new ProfileService(ATProtoClient);
		}

		public async Task<Profile> GetCurrentUserAsync()
		{
			return await profileService.GetProfileAsync(ATProtoClient.Session.AccountHandle);
		}

		public ATProtoClient GetATProtoClient() => ATProtoClient;
	}
}
