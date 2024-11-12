using DarkSky.API.ATProtocol;

namespace DarkSky.API.Tests
{
	public class Tests
	{
		private Client client;
		private string username;
		private string password;
		[OneTimeSetUp]
		public async Task Setup()
		{
			client = new Client();
			username = Environment.GetEnvironmentVariable("BLUESKY_USERNAME");
			password = Environment.GetEnvironmentVariable("BLUESKY_PASSWORD");
			if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
				Assert.Fail("Environment variables are not set.");

			await client.LoginAsync(username, password);
		}

		[Test]
		public void AuthenticationTest()
		{
			ATProtoClient ATProtoClient = client.GetATProtoClient();
			if (ATProtoClient is null || ATProtoClient.Session is null)
				Assert.Fail("Authentication test failed (null)");
			else if(ATProtoClient.Session.AccountHandle != username)
				Assert.Fail("Authentication test failed (incorrect user)");
			else
				Assert.Pass();
		}

		[Test]
		public void GetCurrentProfileTest()
		{
			Assert.Pass();
		}
	}
}