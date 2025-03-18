using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardChart2ViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _DashboardChart2ViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }
        private async Task CarCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var carCount = await httpService.HttpGetSingle("Statistics/CarCount");
            ViewBag.carCount = carCount;
        }

        private async Task BrandCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var brandCount = await httpService.HttpGetSingle("Statistics/BrandCount");
            ViewBag.brandCount = brandCount;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await CarCount();
            await BrandCount();
            return View();
        }
    }
}
