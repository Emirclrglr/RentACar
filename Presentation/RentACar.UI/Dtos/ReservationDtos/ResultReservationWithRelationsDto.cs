namespace RentACar.UI.Dtos.ReservationDtos
{
    public class ResultReservationWithRelationsDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public DateOnly DriverLicenseDate { get; set; }
        public string Description { get; set; }
        public string CarName { get; set; }
        public string PickUpLocationName { get; set; }
        public string DropOffLocationName { get; set; }
    }
}
