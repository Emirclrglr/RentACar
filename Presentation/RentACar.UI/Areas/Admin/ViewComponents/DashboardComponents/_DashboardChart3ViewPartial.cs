using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardChart3ViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _DashboardChart3ViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        private async Task LocationCount()
        {
            HttpService<int> httpService = new(_httpClientFactory, _apiConfig, _client);
            var locationCount = await httpService.HttpGetSingle("Statistics/LocationCount");
            ViewBag.locationCount = locationCount;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await LocationCount();
            return View();
        }
    }
}
