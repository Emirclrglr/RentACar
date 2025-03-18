using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.FooterAddress;

namespace RentACar.UI.ViewComponents.ContactComponents
{
    public class _ContactViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public _ContactViewPartial(IApiConfig apiConfig, IHttpClientFactory httpClientFactory)
        {
            _apiConfig = apiConfig;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}FooterAddresses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultFooterAddressDto>>(jsonData);
                ViewBag.address = values.FirstOrDefault().Address;
                ViewBag.phone = values.FirstOrDefault().Phone;
                ViewBag.email = values.FirstOrDefault().Mail;
                return View();
            }
            return View();
        }
    }
}
