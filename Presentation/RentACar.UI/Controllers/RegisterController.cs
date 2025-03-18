using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.RegisterDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public RegisterController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto dto)
        {
            if (dto.Password == dto.ConfirmPassword)
            {
                HttpService<RegisterDto> httpService = new(_httpClientFactory, _apiConfig, _client);
                var responseMessage = await httpService.HttpPost(dto, "SignUp", Encoding.UTF8);
                if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("", "Dashboard", new { area = "Admin" });
            }
            return View(dto);
        }
    }
}
