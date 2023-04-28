using HolidayApiClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayApiClient.Services
{
	public interface IHolidaysApiService
	{
		Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
	}
}
