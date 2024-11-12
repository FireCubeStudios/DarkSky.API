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
					case "login":
						await client.LoginAsync(input[1], input[2]);
						Console.WriteLine(client.GetATProtoClient().Session.AccountHandle);
						break;
					case "account":
						var user = await client.GetCurrentUserAsync();
						Console.WriteLine("Followers: " + user.Followers);
						break;
					default:
						Console.WriteLine("Invalid command");
						break;
				}
			}
		}
	}
}
