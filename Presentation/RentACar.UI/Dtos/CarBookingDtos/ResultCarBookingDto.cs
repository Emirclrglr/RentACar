namespace RentACar.UI.Dtos.CarBookingDtos
{
    public class ResultCarBookingDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CarId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
