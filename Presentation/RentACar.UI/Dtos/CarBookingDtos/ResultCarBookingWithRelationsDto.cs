namespace RentACar.UI.Dtos.CarBookingDtos
{
    public class ResultCarBookingWithRelationsDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string CarImage { get; set; }
        public decimal Price { get; set; }
        public string PricingName { get; set; }

    }
}
