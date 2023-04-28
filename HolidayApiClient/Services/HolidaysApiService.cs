using HolidayApiClient.Models;
using System.Collections.Generic;
using System.Net.Http;
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

		public Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
		{
			throw new System.NotImplementedException();
		}
	}
}
