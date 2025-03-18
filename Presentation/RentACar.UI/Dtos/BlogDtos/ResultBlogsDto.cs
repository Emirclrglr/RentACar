using Newtonsoft.Json;
using RentACar.UI.APIConnection;
using System.Net.Http;

namespace RentACar.UI.Dtos.BlogDtos
{
    public class ResultBlogsDto
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string CoverImgUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
       
    }
}
