namespace BookingApp.Application.DTOs.Booking
{
    public class RoomTypeWithCapacitiesDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
    }
}
