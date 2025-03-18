using System.Drawing.Printing;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACar.UI.APIConnection;
using RentACar.UI.Dtos.BlogDtos;
using RentACar.UI.HttpService;

namespace RentACar.UI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardLast5BlogsViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _client;

        public _DashboardLast5BlogsViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpService<ResultBlogsDto> httpService = new(_httpClientFactory, _apiConfig, _client);
            var values = await httpService.HttpGet("Blogs/GetAllBlogsWithAuthor");
            var last5Blogs = values.OrderByDescending(x=>x.CreatedDate).Take(6);
            return View(last5Blogs);
        }
    }
}
