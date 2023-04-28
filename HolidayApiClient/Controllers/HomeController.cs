using HolidayApiClient.Models;
using HolidayApiClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayApiClient.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHolidaysApiService _holidaysApiService;



		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public HomeController(IHolidaysApiService holidaysApiService)
		{
			_holidaysApiService = holidaysApiService;
		}

		//public IActionResult Index()
		//{
		//	return View();
		//}

		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> Index(string countryCode, int year)
		{
			List<HolidayModel> holidays = new List<HolidayModel>();
			holidays = await _holidaysApiService.GetHolidays(countryCode, year);

			return View(holidays);
		}
	}
}
