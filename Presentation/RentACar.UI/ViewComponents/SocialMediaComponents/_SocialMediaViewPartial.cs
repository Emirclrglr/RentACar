using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.SocialMediaDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.ViewComponents.SocialMediaComponents
{
    public class _SocialMediaViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _SocialMediaViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient httpClient)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpService<ResultSocialMediaDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("SocialMedias");
            return View(values);
        }
    }
}
