using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.ServiceDtos;

namespace RentACar.UI.ViewComponents.UIComponents
{
    public class _ServicesViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public _ServicesViewPartial(IApiConfig apiConfig, IHttpClientFactory httpClientFactory)
        {
            _apiConfig = apiConfig;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
