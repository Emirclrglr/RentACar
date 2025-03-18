using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.BrandDtos;
using RentACar.UI.Dtos.CarFeatureDtos;
using RentACar.UI.Dtos.FeatureDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public CarFeatureController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            HttpService<ResultCarFeatureByCarIdDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("CarFeatures", id);
            ViewBag.Car = $"{values.Select(x => x.CarBrand).FirstOrDefault()} {values.Select(x => x.CarModel).FirstOrDefault()}";
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> dtos)
        {

            StringContent content = new(JsonConvert.SerializeObject(dtos), Encoding.UTF8, "application/json");
            foreach (var item in dtos)
            {
                if (item.IsAvailable)
                {
                    var response = await _client.GetAsync($"{_apiConfig.BaseUrl}CarFeatures/ChangeCarFeatureIsAvailableToTrue/{item.Id}");
                }
                else
                {
                    var response = await _client.GetAsync($"{_apiConfig.BaseUrl}CarFeatures/ChangeCarFeatureIsAvailableToFalse/{item.Id}");
                }
            }

            return RedirectToAction("", "Car");

        }

        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCar(int id)
        {
            TempData["CarId"] = id;
            HttpService<ResultFeatureDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Features");
            return View(values);
        }
        //[HttpPost]
        //public IActionResult CreateFeatureByCar(List<CreateCarFeatureDto> dtos)
        //{
            
        //}

    }
}
