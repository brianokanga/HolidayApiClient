﻿using HolidayApiClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HolidayApiClient.Services
{
	public class HolidaysApiService : IHolidaysApiService
	{
		private static readonly HttpClient client;

		static HolidaysApiService() 
		{ 
			client = new HttpClient() 
			{
				BaseAddress = new System.Uri("https://date.nager.at")
			};
		}

		public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
		{
			var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", 
				countryCode, year);
			var result = new List<HolidayModel>();
			var response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode) 
			{
				var stringResponse = await response.Content.ReadAsStringAsync();
				result = JsonSerializer.Deserialize<List<HolidayModel>>(
					stringResponse,new JsonSerializerOptions() 
					{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
			}
			else
			{
				throw new HttpRequestException(response.ReasonPhrase);
			}
			return result;
		}
	}
}
