using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DarkSky.API.Classes
{
	public record Post(
		string Uri,
		string CID,
		Author Author,
		int ReplyCount,
		int RepostCount,
		int LikeCount,
		int QuoteCount
	);
}
