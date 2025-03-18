namespace RentACar.UI.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
    }
}
