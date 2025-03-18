namespace RentACar.UI.Dtos.CarFeatureDtos
{
    public class CreateCarFeatureDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
