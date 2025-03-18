namespace RentACar.UI.Dtos.BlogDtos
{
    public class ResultLast3BlogsWithAuthorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CoverImgUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
