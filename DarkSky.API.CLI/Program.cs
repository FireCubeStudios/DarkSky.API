using DarkSky.API.Services;

namespace DarkSky.API.CLI
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			bool run = true;
			Client client = new Client();
			while (run)
			{
				string[] input = Console.ReadLine().Split(" ");
				switch (input[0])
				{
					case "exit":
						run = false;
						break;
					case "refresh":
						await client.RefreshManualAsync(input[1]);
						Console.WriteLine(Client.ATProtoClient.Session.AccountHandle);
						Console.WriteLine(Client.ATProtoClient.Session.RefreshToken);
						break;
					case "login":
						await client.LoginAsync(input[1], input[2]);
						Console.WriteLine(Client.ATProtoClient.Session.AccountHandle);
						Console.WriteLine(Client.ATProtoClient.Session.RefreshToken);
						break;
					case "account":
						var user = client.CurrentProfile;
						Console.WriteLine(user.DisplayName);
						Console.WriteLine(user.DID);
						break;
					case "timeline":
						var feedT = await FeedService.GetTimelineAsync();
						foreach (var item in feedT)
						{
							Console.WriteLine(item.LikeCount);
							Console.WriteLine(item.ReplyCount);
							Console.WriteLine(item.Author.DisplayName);
						}
						break;
					case "accountfeed":
						var feed = await client.CurrentProfile.GetProfileFeedAsync();
						foreach(var item in feed)
						{
							Console.WriteLine(item.LikeCount);
							Console.WriteLine(item.Author.DisplayName);
						}
						break;
					default:
						Console.WriteLine("Invalid command");
						break;
				}
			}
		}
	}
}
