namespace RentACar.UI.Dtos.ReviewDtos
{
    public class ResultReviewDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RatingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
    }
}
