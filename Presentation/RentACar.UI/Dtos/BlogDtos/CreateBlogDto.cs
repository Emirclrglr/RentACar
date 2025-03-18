namespace RentACar.UI.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string CoverImgUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
