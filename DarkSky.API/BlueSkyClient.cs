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
	public class BlueSkyClient
	{
		public static ATProtoClient ATProtoClient { get; set; } = new ATProtoClient();
		public Profile CurrentProfile { get; set; } // Get the authenticated account's profile
		private AuthService authService = new AuthService();

		public async Task LoginAsync(string Username, string AppPassword)
		{
			ATProtoClient = await authService.LoginAsync(Username, AppPassword);
			CurrentProfile = await ProfileService.GetProfileAsync(ATProtoClient.Session.AccountDID);
		}

		public async Task RefreshManualAsync(string token)
		{
			ATProtoClient.Session = new AuthSession(token);
			ATProtoClient = await authService.RefreshAsync(ATProtoClient);
			CurrentProfile = await ProfileService.GetProfileAsync(ATProtoClient.Session.AccountDID);
		}
	}
}
