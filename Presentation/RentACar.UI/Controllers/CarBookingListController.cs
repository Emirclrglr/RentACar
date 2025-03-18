using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarBookingDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;

namespace RentACar.UI.Controllers
{
    public class CarBookingListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public CarBookingListController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index(int id, int page = 1, int pageSize = 12)
        {
            var locationId = TempData["locationId"];

            id = int.Parse(locationId.ToString()); 

            ViewBag.locationId = locationId;


            HttpService<ResultCarBookingWithRelationsDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("CarBookings/GetCarBookingsByLocationWithRelations", id);
            return View(values.ToPagedList(page, pageSize));
        }
    }
}
