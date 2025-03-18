namespace RentACar.UI.Dtos.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarFeatureName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
