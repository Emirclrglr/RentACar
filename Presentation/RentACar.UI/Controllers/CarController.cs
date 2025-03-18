using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarDtos;
using X.PagedList.Extensions;
namespace RentACar.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public CarController(IApiConfig apiConfig, IHttpClientFactory httpClientFactory)
        {
            _apiConfig = apiConfig;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}Cars/GetCarWithBrandAndPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultCarWithBrandAndPricingDto>>(jsonData);
                return View(values.ToPagedList(page, pageSize));
            }
            return View();
        }

        public IActionResult CarDetails(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
