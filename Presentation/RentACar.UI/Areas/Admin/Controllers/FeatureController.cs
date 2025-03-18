using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.FeatureDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;
using X.PagedList.Mvc.Core;
namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public FeatureController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            HttpService<ResultFeatureDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Features");
            return View(values.ToPagedList(page, pageSize));
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            HttpService<CreateFeatureDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPost(dto, "Features", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            HttpService<UpdateFeatureDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Features", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            HttpService<UpdateFeatureDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPut(dto, "Features", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            HttpService<DeleteFeatureDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpDelete("Features", id);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
