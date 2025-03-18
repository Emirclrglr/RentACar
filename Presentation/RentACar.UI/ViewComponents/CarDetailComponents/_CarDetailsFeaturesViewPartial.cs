using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarFeatureDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.ViewComponents.CarDetailComponents
{
    public class _CarDetailsFeaturesViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _CarDetailsFeaturesViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            HttpService<ResultCarFeatureByCarIdDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("CarFeatures", id);
            return View(values);
        }
    }
}
