using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarDescriptionDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.ViewComponents.CarDetailComponents
{
    public class _CarDetailsDescriptionViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _CarDetailsDescriptionViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            HttpService<ResultCarDescriptionDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("CarDescriptions/GetCarDescriptionByCarId", id);
            return View(values);
        }
    }
}
