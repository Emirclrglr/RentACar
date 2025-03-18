using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.CarDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.ViewComponents.CarDetailComponents
{
    public class _CarDetailsMainCarFeaturesViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _CarDetailsMainCarFeaturesViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            HttpService<ResultCarWithBrandDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetSingle("Cars/GetCarByIdWithBrand", id);
            
            return View(values);
        }
    }
}
