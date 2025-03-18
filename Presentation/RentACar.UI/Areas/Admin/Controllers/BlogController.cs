using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.AuthorDtos;
using RentACar.UI.Dtos.BlogDtos;
using RentACar.UI.Dtos.CategoryDtos;
using RentACar.UI.Dtos.CommentDtos;
using RentACar.UI.HttpService;
using X.PagedList.Extensions;

namespace RentACar.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public BlogController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }
        private async Task CategoryList()
        {
            HttpService<ResultCategoryDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Categories");
            List<SelectListItem> categoryList = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.categoryList = categoryList;
        }

        private async Task AuthorList()
        {
            HttpService<ResultAuthorDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Authors");
            List<SelectListItem> authorList = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.authorList = authorList;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            HttpService<ResultBlogsDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Blogs/GetAllBlogsWithAuthor");
            return View(values.ToPagedList(page, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await CategoryList();
            await AuthorList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto dto)
        {
            await CategoryList();
            await AuthorList();
            HttpService<CreateBlogDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPost(dto, "Blogs", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            await CategoryList();
            await AuthorList();
            HttpService<UpdateBlogDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGetById("Blogs/GetBlogDetailsWithAuthorDetails", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto)
        {
            await CategoryList();
            await AuthorList();
            HttpService<UpdateBlogDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpPut(dto, "Blogs", Encoding.UTF8);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteBlog(DeleteBlogDto dto)
        {
            HttpService<DeleteBlogDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var responseMessage = await httpService.HttpDelete("Blogs", dto.Id);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> BlogComments(int id)
        {
            HttpService<ResultCommentDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Comments/GetCommentsByBlogId", id);
            return View(values);
        }
    }
}
