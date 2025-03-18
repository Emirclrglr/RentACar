using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;
        CultureInfo cultureInfo = new CultureInfo("tr-TR");
        public StatisticsController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
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

        private async Task AuthorCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var authorCount = await httpService.HttpGetSingle("Statistics/AuthorCount");
            ViewBag.authorCount = authorCount;
        }

        private async Task BlogCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var blogCount = await httpService.HttpGetSingle("Statistics/BlogCount");
            ViewBag.blogCount = blogCount;
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

        private async Task AverageHourlyCarRentalPrice()
        {
            HttpService<decimal> httpService = new(_httpClientFactory, _apiConfig, _client);
            var averageHourlyCarRentalPrice = await httpService.HttpGetSingle("Statistics/AverageHourlyCarRentalPrice");
            var price = averageHourlyCarRentalPrice / 1000000;
            ViewBag.averageHourlyCarRentalPrice = price.ToString("C2", cultureInfo);
        }

        private async Task AverageWeeklyCarRentalPrice()
        {
            HttpService<decimal> httpService = new(_httpClientFactory, _apiConfig, _client);
            var averageWeeklyCarRentalPrice = await httpService.HttpGetSingle("Statistics/AverageWeeklyCarRentalPrice");
            var price = averageWeeklyCarRentalPrice / 1000000;
            ViewBag.averageWeeklyCarRentalPrice = price.ToString("C2", cultureInfo);
        }

        private async Task AutomaticCarCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var automaticCarCount = await httpService.HttpGetSingle("Statistics/AutomaticCarCount");
            ViewBag.automaticCarCount = automaticCarCount;
        }

        private async Task BrandWithTheMostVehicles()
        {
            HttpService<string> httpService = new(_httpClientFactory, _apiConfig, _client);
            var brandWithTheMostVehicles = await httpService.HttpGetSingle("Statistics/BrandWithTheMostVehicles");
            ViewBag.brandWithTheMostVehicles = brandWithTheMostVehicles.ToString();
        }

        private async Task VehicleCountWithLessThan1000KmAsync()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var vehicleCountWithLessThan1000KmAsync = await httpService.HttpGetSingle("Statistics/VehicleCountWithLessThan1000KmAsync");
            ViewBag.vehicleCountWithLessThan1000KmAsync = vehicleCountWithLessThan1000KmAsync;
        }

        private async Task VehicleCountByFuelTypeGasOrDiesel()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var vehicleCountByFuelTypeGasOrDiesel = await httpService.HttpGetSingle("Statistics/VehicleCountByFuelTypeGasOrDiesel");
            ViewBag.vehicleCountByFuelTypeGasOrDiesel = vehicleCountByFuelTypeGasOrDiesel;
        }

        private async Task VehicleCountByFuelTypeElectric()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var vehicleCountByFuelTypeElectric = await httpService.HttpGetSingle("Statistics/VehicleCountByFuelTypeElectric");
            ViewBag.vehicleCountByFuelTypeElectric = vehicleCountByFuelTypeElectric;
        }

        private async Task MostExpensiveVehicle()
        {
            HttpService<string> httpService = new(_httpClientFactory, _apiConfig, _client);
            var mostExpensiveVehicle = await httpService.HttpGetSingle("Statistics/MostExpensiveVehicle");
            ViewBag.mostExpensiveVehicle = mostExpensiveVehicle;
        }

        private async Task CheapestVehicle()
        {
            HttpService<string> httpService = new(_httpClientFactory, _apiConfig, _client);
            var cheapestVehicle = await httpService.HttpGetSingle("Statistics/CheapestVehicle");
            ViewBag.cheapestVehicle = cheapestVehicle;
        }

        private async Task ServiceCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var serviceCount = await httpService.HttpGetSingle("Statistics/ServiceCount");
            ViewBag.serviceCount = serviceCount;
        }

        public async Task<IActionResult> Index()
        {
            #region Statistic Methods
            await CarCount();
            await LocationCount();
            await AuthorCount();
            await BlogCount();
            await BrandCount();
            await AverageDailyCarRentalPrice();
            await AverageHourlyCarRentalPrice();
            await AverageWeeklyCarRentalPrice();
            await AutomaticCarCount();
            await BrandWithTheMostVehicles();
            await VehicleCountWithLessThan1000KmAsync();
            await VehicleCountByFuelTypeGasOrDiesel();
            await VehicleCountByFuelTypeElectric();
            await MostExpensiveVehicle();
            await CheapestVehicle();
            await ServiceCount();
            #endregion

            return View();
        }
    }
}
