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

		public async Task Login(String Username, String AppPassword)
		{
			ATProtoClient = await authService.LoginAsync(Username, AppPassword);
		}

		public async Task<Profile> GetCurrentUserAsync()
		{
			profileService = new ProfileService(ATProtoClient);
			return await profileService.GetProfileAsync(ATProtoClient.Session.AccountHandle);
		}
	}
}
