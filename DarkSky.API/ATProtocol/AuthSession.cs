using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.API.ATProtocol
{
	/*
	 * Stores the current authentication session data
	 * AccountDID: Domain-Identifier (at://did:plc123.xyz/)
	 * AccountHande: firecube.bsky.social
	 * PDSUrl: Accounts are stored on a PDS. Used for authenticated requests. 
	 * https://docs.bsky.app/docs/advanced-guides/entryway
	 */

	/// Since .NET Standard 2.1 does not support records this is commented out
	///public record AuthSession(string? AccountDID, string? AccountHandle, string? PDSUrl, string? AccessToken, string? RefreshToken);
	///
	public class AuthSession
	{
		public string AccountDID { get; set; }
		public string AccountHandle { get; set; }
		public string PDSUrl { get; set; }
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }

		// Constructor
		public AuthSession(string accountDID, string accountHandle, string pdsUrl, string accessToken, string refreshToken)
		{
			AccountDID = accountDID;
			AccountHandle = accountHandle;
			PDSUrl = pdsUrl;
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
	}
}
