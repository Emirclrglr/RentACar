using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardStatisticsViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;
        CultureInfo cultureInfo = new CultureInfo("tr-TR");

        public _DashboardStatisticsViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
            cultureInfo.NumberFormat.CurrencyPositivePattern = 3;
        }

        private async Task CarCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var carCount = await httpService.HttpGetSingle("Statistics/CarCount");
            ViewBag.carCount = carCount;
        }

        private async Task LocationCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var locationCount = await httpService.HttpGetSingle("Statistics/LocationCount");
            ViewBag.locationCount = locationCount;
        }

        private async Task BrandCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var brandCount = await httpService.HttpGetSingle("Statistics/BrandCount");
            ViewBag.brandCount = brandCount;
        }

        private async Task AverageDailyCarRentalPrice()
        {
            HttpService<decimal> httpService = new(_httpClientFactory, _apiConfig, _client);
            var averageDailyCarRentalPrice = await httpService.HttpGetSingle("Statistics/AverageDailyCarRentalPrice");
            var price = averageDailyCarRentalPrice / 1000000;
            ViewBag.averageDailyCarRentalPrice = price.ToString("C2", cultureInfo);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await CarCount();
            await LocationCount();
            await BrandCount();
            await AverageDailyCarRentalPrice();
            return View();
        }
    }
}
