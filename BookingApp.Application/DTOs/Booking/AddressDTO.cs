namespace BookingApp.Application.DTOs.Booking
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int CityId { get; set; }
    }
}
