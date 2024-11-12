using DarkSky.API.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DarkSky.API.Classes
{
	// An author for a post
	// TEMPORARY
	public record Author(
		string DID,
		string Handle,
		string DisplayName,
		Uri Avatar,
		DateTime CreatedAt
	){
		public async Task<Profile> GetProfileAsync() => await ProfileService.GetProfileAsync(DID);
	}
}
