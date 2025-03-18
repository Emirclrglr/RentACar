using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarPricingDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;

namespace RentACar.UI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardCarPricingListViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _DashboardCarPricingListViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 5)
        {
            HttpService<ResultCarPricingWithTimePeriodDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("CarPricings");
            return View(values.ToPagedList(page, pageSize));
        }
    }
}
