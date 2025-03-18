using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.BlogDtos;
using RentACar.UI.Dtos.CommentDtos;
using X.PagedList;
using X.PagedList.Extensions;
namespace RentACar.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;


        public BlogController(IApiConfig apiConfig, IHttpClientFactory httpClientFactory)
        {
            _apiConfig = apiConfig;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBlogsDto>>(jsonData);
                var pagedList = values.ToPagedList(page, pageSize);

                return View(pagedList);
            }
            return View();
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.BlogId = id;
            TempData["blogId"] = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult LeaveAComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> LeaveAComment(CreateCommentDto dto)
        {
            dto.BlogId = (int)TempData["blogId"];
            var client = _httpClientFactory.CreateClient();
            StringContent content = new(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiConfig.BaseUrl}Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetails", new { Id = dto.BlogId });
            }


            return View();
        }
    }
}


