using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.TestimonialDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public TestimonialController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            HttpService<ResultTestimonialDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Testimonials");
            return View(values.ToPagedList(page, pageSize));
        }

        public async Task<IActionResult> TestimonialComment(int id)
        {
            HttpService<ResultTestimonialDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Testimonials", id);
            return Json(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            HttpService<CreateTestimonialDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPost(dto, "Testimonials", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            HttpService<UpdateTestimonialDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Testimonials", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            HttpService<UpdateTestimonialDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPut(dto, "Testimonials", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(DeleteTestimonialDto dto)
        {
            HttpService<DeleteTestimonialDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpDelete("Testimonials", dto.Id);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
