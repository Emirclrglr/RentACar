using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarDtos;
using RentACar.UI.Dtos.LocationDtos;
using RentACar.UI.Dtos.ReservationDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public ReservationController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        private async Task LocationList()
        {
            HttpService<ResultLocationDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Locations");
            List<SelectListItem> locationList = (from item in values
                                                 select new SelectListItem
                                                 {
                                                     Text = item.LocationName,
                                                     Value = item.Id.ToString()
                                                 }).ToList();
            ViewBag.locationList = locationList;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.carid = id;
            await LocationList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto dto)
        {
            await LocationList();
            HttpService<CreateReservationDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPost(dto, "Reservations", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("", "Home");
            return View();
        }
    }
}
