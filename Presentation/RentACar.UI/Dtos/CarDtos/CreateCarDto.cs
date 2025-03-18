namespace RentACar.UI.Dtos.CarDtos
{
    public class CreateCarDto
    {
        public string Model { get; set; }
        public string CoverIMG { get; set; }
        public string BigIMG { get; set; }
        public int Kilometer { get; set; }
        public string Transmission { get; set; }
        public byte Seats { get; set; }
        public byte Luggage { get; set; }
        public string FuelType { get; set; }
        public int BrandId { get; set; }
    }
}
