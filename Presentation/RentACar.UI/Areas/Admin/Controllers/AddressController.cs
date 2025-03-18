using System.Text;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.FooterAddress;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public AddressController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            HttpService<ResultFooterAddressDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("FooterAddresses");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(int id)
        {
            HttpService<UpdateFooterAddressDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("FooterAddresses", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(UpdateFooterAddressDto dto)
        {
            HttpService<UpdateFooterAddressDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPut(dto, "FooterAddresses", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
