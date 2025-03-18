namespace RentACar.UI.Dtos.CarDtos
{
    public class ResultCarWithBrandAndPricingDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string CoverIMG { get; set; }
        public string BigIMG { get; set; }
        public int Kilometer { get; set; }
        public string Transmission { get; set; }
        public byte Seats { get; set; }
        public byte Luggage { get; set; }
        public string FuelType { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string PricingName { get; set; }
    }
}
