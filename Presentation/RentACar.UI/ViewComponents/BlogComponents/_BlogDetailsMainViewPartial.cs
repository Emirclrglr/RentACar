using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.BlogDtos;

namespace RentACar.UI.ViewComponents.BlogComponents
{
    public class _BlogDetailsMainViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public _BlogDetailsMainViewPartial(IApiConfig apiConfig, IHttpClientFactory httpClientFactory)
        {
            _apiConfig = apiConfig;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogsDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
