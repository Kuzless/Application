namespace BookingApp.Application.DTOs.Booking
{
    public class RoomTypesForNewBookingDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
    }
}
