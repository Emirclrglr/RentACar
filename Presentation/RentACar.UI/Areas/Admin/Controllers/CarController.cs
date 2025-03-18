using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.BrandDtos;
using RentACar.UI.Dtos.CarDtos;
using RentACar.UI.HttpService;
using X.PagedList;
using X.PagedList.Extensions;
namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public CarController(HttpClient client, IApiConfig apiConfig, IHttpClientFactory httpClientFactory)
        {
            _client = client;
            _apiConfig = apiConfig;
            _httpClientFactory = httpClientFactory;
        }

        private async Task BrandList()
        {
            HttpService<ResultBrandDto> httpService = new(_httpClientFactory, _apiConfig, _client);

            var values = await httpService.HttpGet("Brands");

            List<SelectListItem> brandDropDownList = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.BrandName,
                                                          Value = x.Id.ToString()
                                                      }).ToList();
            ViewBag.brandList = brandDropDownList;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            HttpService<ResultCarWithBrandDto> httpService = new(_httpClientFactory, _apiConfig, _client);

            var values = await httpService.HttpGet("Cars/GetCarWithBrand");

            return View(values.ToPagedList(page, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            await BrandList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto dto)
        {
            await BrandList();

            HttpService<CreateCarDto> httpService = new(_httpClientFactory, _apiConfig, _client);

            var responseMessage = await httpService.HttpPost(dto, "Cars", Encoding.UTF8);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            HttpService<DeleteCarDto> httpService = new(_httpClientFactory, _apiConfig, _client);

            var responseMessage = await httpService.HttpDelete("Cars", id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            await BrandList();

            HttpService<UpdateCarDto> httpService = new(_httpClientFactory, _apiConfig, _client);

            var values = await httpService.HttpGetById("Cars", id);

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            await BrandList();

            HttpService<UpdateCarDto> httpService = new(_httpClientFactory, _apiConfig, _client);

            var responseMessage = await httpService.HttpPut(dto, "Cars", Encoding.UTF8);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        
    }
}
