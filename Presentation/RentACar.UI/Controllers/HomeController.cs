using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.LocationDtos;
using RentACar.UI.HttpService;
using RentACar.UI.Models;

namespace RentACar.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public HomeController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        private async Task LocationList()
        {
            HttpService<ResultLocationDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Locations");
            List<SelectListItem> locationList = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.LocationName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.locationList = locationList;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await LocationList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationId)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationId"] = locationId;
            return RedirectToAction("", "CarBookingList");
        }
    }
}
