using System.Text;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.ServiceDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public ServiceController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            HttpService<ResultServiceDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Services");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            HttpService<UpdateServiceDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Services", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            HttpService<UpdateServiceDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPut(dto, "Services", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

       
    }
}
