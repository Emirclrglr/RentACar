using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.ContactDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            HttpService<ResultContactDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Contacts");
            return View(values.ToPagedList(page, pageSize));
        }

        public async Task<IActionResult> MessageDetails(int id)
        {
            HttpService<ResultContactDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Contacts", id);
            return Json(values);
        }

        public async Task<IActionResult> DeleteContact(DeleteContactDto dto)
        {
            HttpService<DeleteContactDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpDelete("Contacts", dto.Id);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
