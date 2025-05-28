namespace BookingApp.Application.DTOs.Booking
{
    public class BookingEditDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<RoomTypesForNewBookingDTO> RoomTypes { get; set; }
    }
}
