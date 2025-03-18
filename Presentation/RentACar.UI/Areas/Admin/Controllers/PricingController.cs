using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.PricingDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public PricingController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            HttpService<ResultPricingDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Pricings");
            return View(values.ToPagedList(page, pageSize));
        }

        [HttpGet]
        public IActionResult CreatePricing()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto dto)
        {
            HttpService<CreatePricingDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPost(dto, "Pricings", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            HttpService<UpdatePricingDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Pricings", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto dto)
        {
            HttpService<UpdatePricingDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPut(dto, "Pricings", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeletePricing(DeletePricingDto dto)
        {
            HttpService<DeletePricingDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpDelete("Pricings", dto.Id);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
