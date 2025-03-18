namespace RentACar.UI.Dtos.CarPricingDtos
{
    public class ResultCarPricingWithTimePeriodDto
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string CoverIMG { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal HourlyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
    }
}
